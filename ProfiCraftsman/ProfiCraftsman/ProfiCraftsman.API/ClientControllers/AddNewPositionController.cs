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
using ProfiCraftsman.API.Controllers;

namespace ProfiCraftsman.API.ClientControllers
{
    public class AddNewPositionController : ApiController
	{
	    private readonly ITermsManager termManager;
        private readonly IProductsManager productManager;
        private readonly IPositionsManager positionsManager;

        public AddNewPositionController(ITermsManager termManager, IProductsManager productManager, IPositionsManager positionsManager)
	    {
	        this.termManager = termManager;
	        this.productManager = productManager;
	        this.positionsManager = positionsManager;
        }

	    public IHttpActionResult Post([FromBody]AddNewPositionModel model)
		{
            var term = termManager.GetById(model.termId);
            ClientTermViewModel result = null;

            //TODO security check (user id)
            var product = productManager.GetById(model.productId);
            if (product != null && term != null)
            {
                var newPosition = new Positions()
                {
                    Amount = 1, //TODO
                    Description = product.Name,
                    ProductId = product.Id,
                    Price = product.Price,
                    OrderId = term.OrderId,
                };

                positionsManager.AddEntity(newPosition);

                positionsManager.SaveChanges();

                term.TermPositions.Add(new TermPositions()
                {
                    TermId = term.Id,
                    Amount = 1, //TODO
                    Positions = newPosition,
                });

                positionsManager.SaveChanges();

                if (term != null)
                {
                    result = TermViewModelHelper.ToModel(term, true, false);
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