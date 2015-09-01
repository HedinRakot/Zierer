using System.Linq;
using System.Web.Http;
using System.Web.Security;
using ProfiCraftsman.API.Models;
using ProfiCraftsman.Contracts.Managers;
using CoreBase;
using CoreBase.Models;
using System;
using System.Collections.Generic;
using ProfiCraftsman.Contracts.Enums;
using System.Linq;
using ProfiCraftsman.Contracts.Entities;
using System.Net.Mail;
using System.Net;
using ProfiCraftsman.API.Config;
using System.IO;
using System.Web;

namespace ProfiCraftsman.API.ClientControllers
{
    public class ChangeTermStateController : ApiController
	{
	    private readonly ITermsManager termManager;
        private readonly IUserManager userManager;
        private readonly IDeliveryNoteSignaturesManager deliveryNoteSignaturesManager;
        private readonly IPrinterManager printerManager;

        public ChangeTermStateController(ITermsManager termManager, IUserManager userManager, 
            IDeliveryNoteSignaturesManager deliveryNoteSignaturesManager, IPrinterManager printerManager)
	    {
	        this.termManager = termManager;
	        this.userManager = userManager;
	        this.deliveryNoteSignaturesManager = deliveryNoteSignaturesManager;
            this.printerManager = printerManager;
        }

	    public IHttpActionResult Post([FromBody]ChangeStateTermModel model)
		{
            var term = termManager.GetById(model.termId);
            ClientTermViewModel result = null;

            //TODO security check (user id)
            var user = userManager.GetByLogin(model.Login);
            if (user != null && term != null)
            {
                term.User = user;
                term.Status = model.status;

                switch ((TermStatusTypes)model.status)
                {
                    case TermStatusTypes.BeginTrip:
                        term.BeginTripFromOffice = model.BeginTripFromOffice;
                        term.BeginTrip = DateTime.Now;
                        break;
                    case TermStatusTypes.EndTrip:
                        term.EndTrip = DateTime.Now;
                        break;
                    case TermStatusTypes.BeginWork:
                        term.BeginWork = DateTime.Now;
                        break;
                    case TermStatusTypes.CheckPositions:

                        var termPositions = term.TermPositions.Where(o => !o.DeleteDate.HasValue).ToList();
                        foreach(var position in model.Positions)
                        {
                            var termPosition = termPositions.FirstOrDefault(o => o.Id == position.Id);
                            termPosition.ProccessedAmount = position.ProccessedAmount;
                        }

                        termManager.SaveChanges();
                        break;
                    case TermStatusTypes.CheckMaterials:

                        var termMaterials = term.TermPositions.Where(o => !o.DeleteDate.HasValue).SelectMany(o => o.Positions.PositionMaterialRsps).ToList();
                        foreach (var material in model.Materials)
                        {
                            var termMaterial = termMaterials.FirstOrDefault(o => o.Id == material.Id);
                            termMaterial.Amount = material.Amount;
                        }

                        termManager.SaveChanges();
                        break;
                    case TermStatusTypes.EndWork:
                        term.EndWork = DateTime.Now;

                        var dataDirectory = Path.Combine(HttpRuntime.AppDomainAppPath, "App_Data");
                        var path = Path.Combine(dataDirectory, Contracts.Configuration.DeliveryNoteFileName);
                        var stream = printerManager.PrepareDeliveryNotePrintData(term.Id, path, termManager);

                        var fileName = String.Format("Lieferscheine_{0}_{1}_{2}_{3}.pdf", term.Id, DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                        var directory = Path.Combine(HttpRuntime.AppDomainAppPath, "Lieferscheine");
                        var filePath = Path.Combine(directory, fileName);

                        if (!Directory.Exists(directory))
                            Directory.CreateDirectory(directory);

                        var fileStream = new FileStream(filePath, FileMode.Create);
                        stream.WriteTo(fileStream);

                        term.DeliveryNoteFileName = fileName;
                        termManager.SaveChanges();

                        var attachments = new List<Attachment>();
                        stream.Position = 0;
                        attachments.Add(new Attachment(stream, fileName)); 

                        if (model.sendDeliveryNotePerEmail)
                        {
                            SendMail(NotificationServerConfigSection.Instance.SmtpServer,
                                NotificationServerConfigSection.Instance.SmtpServerAccountName,
                                NotificationServerConfigSection.Instance.SmtpServerAccountPassword,
                                term.Orders.Customers.Email,
                                String.Format("Lieferschein {0}", DateTime.Now.ToShortDateString()),
                                String.Format("<p>Sehr geehrte {0},</p><p>anbei der Lieferschein vom {1}.</p><p>Mit freundlichen Grüßen,</p><p>{2}</p>",
                                    term.Orders.Customers.Name, DateTime.Now.ToShortDateString(), "Firma Zierer Gebäude & Systemtechnik"),
                                NotificationServerConfigSection.Instance.SmtpServerPort,
                                NotificationServerConfigSection.Instance.EnableSsl,
                                (SmtpDeliveryMethod)NotificationServerConfigSection.Instance.SmtpDeliveryMethod, true,
                                attachments);
                        }
                        else
                        {
                            var signature = deliveryNoteSignaturesManager.GetEntities(o => o.TermId == model.termId).FirstOrDefault();
                            if (signature != null)
                            {
                                signature.Signature = model.signature;
                            }
                            else
                            {
                                deliveryNoteSignaturesManager.AddEntity(new DeliveryNoteSignatures()
                                {
                                    TermId = model.termId,
                                    Signature = model.signature,
                                });
                            }

                            deliveryNoteSignaturesManager.SaveChanges();
                        }

                        break;
                    case TermStatusTypes.BeginReturnTrip:
                        term.BeginReturnTrip = DateTime.Now;
                        break;
                    case TermStatusTypes.EndReturnTrip:
                        term.EndReturnTrip = DateTime.Now;
                        break;
                }

                termManager.SaveChanges();

                if (term != null)
                {
                    result = TermViewModelHelper.ToModel(term, model.withPositions, model.withMaterials);
                }

                return Ok(result);
            }

            return BadRequest();
		}

        private void SendMail(string smtpServer, string @from, string password, string mailto, string caption, string message, int port, bool enableSsl, 
            SmtpDeliveryMethod smtpDeliveryMethod, bool isBodyHtml,
            IEnumerable<Attachment> attachments)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(from);
                mail.To.Add(new MailAddress(mailto));
                mail.Subject = caption;
                mail.Body = message;
                mail.IsBodyHtml = isBodyHtml;

                foreach (var attachment in attachments)
                {
                    mail.Attachments.Add(attachment);
                }

                SmtpClient client = new SmtpClient
                {
                    Host = smtpServer,
                    Port = port,
                    EnableSsl = enableSsl,
                    Credentials = new NetworkCredential(@from.Split('@')[0], password),
                    DeliveryMethod = smtpDeliveryMethod
                };
                client.Send(mail);
                mail.Dispose();
            }
            catch (Exception e)
            {
                //throw new Exception("Mail.Send: " + e.Message);
            }
        }
    }
}