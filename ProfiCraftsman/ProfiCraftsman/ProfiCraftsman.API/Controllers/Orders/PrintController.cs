using ProfiCraftsman.API.Security;
using ProfiCraftsman.Contracts.Enums;
using ProfiCraftsman.Contracts.Managers;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;
using System.Linq;
using System.Collections.Generic;
using CoreBase.ActionResults;
using CoreBase.Controllers;

namespace ProfiCraftsman.API.Controllers
{
    
    /// <summary>
    ///     Controller for printing
    /// </summary>
    [AuthorizeByPermissions(PermissionTypes = new[] { Permissions.Orders })]
    public partial class PrintController: ApiController
    {
        private ITaxesManager taxesManager;
        private IInvoicesManager invoicesManager;
        private IInvoiceStornosManager invoiceStornosManager;
        private ITransportOrdersManager transportOrdersManager;
        private IPrinterManager printerManager;
        private ITermsManager termsManager;

        public PrintController(IOrdersManager manager, IInvoicesManager invoicesManager, 
            IInvoiceStornosManager invoiceStornosManager, ITaxesManager taxesManager,
            ITransportOrdersManager transportOrdersManager, IPrinterManager printerManager,
            ITermsManager termsManager) :
            base()
        {
            this.taxesManager = taxesManager;
            this.invoicesManager = invoicesManager;
            this.invoiceStornosManager = invoiceStornosManager;
            this.transportOrdersManager = transportOrdersManager;
            this.printerManager = printerManager;
            this.termsManager = termsManager;
            Manager = manager;
            FilterExpressionCreator = new FilterExpressionCreator();
        }

        private IOrdersManager Manager { get; set; }
        private IFilterExpressionCreator FilterExpressionCreator { get; set; }

        public IHttpActionResult Get([FromUri]GridArgs args, int id, int printTypeId)
		{
            string path = String.Empty;
            var dataDirectory = Path.Combine(HttpRuntime.AppDomainAppPath, "App_Data");
            var report = (PrintTypes)printTypeId;
            Stream stream = null;

            switch (report)
            {
                case PrintTypes.Order:
                    path = Path.Combine(dataDirectory, Contracts.Configuration.OrderFileName);
                    stream = printerManager.PrepareOrderPrintData(id, path, taxesManager, Manager);
                    break;
                case PrintTypes.Offer:
                    path = Path.Combine(dataDirectory, Contracts.Configuration.OfferFileName);
                    stream = printerManager.PrepareOfferPrintData(id, path, taxesManager, Manager);
                    break;
                case PrintTypes.Invoice:
                    path = Path.Combine(dataDirectory, Contracts.Configuration.InvoiceFileName);
                    stream = printerManager.PrepareInvoicePrintData(id, path, invoicesManager, Manager);
                    break;
                case PrintTypes.ReminderMail:
                    path = Path.Combine(dataDirectory, Contracts.Configuration.ReminderFileName);

                    var invoices = invoicesManager.GetEntities(o => !o.PayDate.HasValue && o.ReminderCount < 3 &&
                        ( (!o.LastReminderDate.HasValue && o.CreateDate.AddDays(o.PayInDays) < DateTime.Now) ||
                          (o.LastReminderDate.HasValue && o.LastReminderDate.Value.AddDays(8) < DateTime.Now)
                        )).ToList();

                    foreach(var invoice in invoices)
                    {
                        invoice.LastReminderDate = DateTime.Now;
                        invoice.ReminderCount++;
                    }

                    invoicesManager.SaveChanges();

                    var newIds = invoices.Select(o => o.Id).ToList();

                    var allInvoicesToReminder = new List<Contracts.Entities.Invoices>(invoices);
                    allInvoicesToReminder.AddRange(invoicesManager.GetEntities(o => !o.PayDate.HasValue && o.ReminderCount != 0 &&
                        !newIds.Contains(o.Id)).ToList());

                    stream = printerManager.PrepareReminderPrintData(allInvoicesToReminder, path, invoicesManager, taxesManager, Manager);
                    break;
                case PrintTypes.InvoiceStorno:
                    path = Path.Combine(dataDirectory, Contracts.Configuration.InvoiceStornoFileName);
                    stream = printerManager.PrepareInvoiceStornoPrintData(id, path, invoiceStornosManager, Manager);
                    break;
                case PrintTypes.DeliveryNote:

                    var term = termsManager.GetById(id);

                    if (!String.IsNullOrEmpty(term.DeliveryNoteFileName))
                    {
                        var directory = Path.Combine(HttpRuntime.AppDomainAppPath, "Lieferscheine");
                        var filePath = Path.Combine(directory, term.DeliveryNoteFileName);

                        if (File.Exists(filePath))
                        {
                            stream = File.OpenRead(filePath);
                        }
                        else
                        {
                            path = Path.Combine(dataDirectory, Contracts.Configuration.DeliveryNoteFileName);
                            stream = printerManager.PrepareDeliveryNotePrintData(id, path, termsManager);
                        }
                    }
                    else
                    {
                        path = Path.Combine(dataDirectory, Contracts.Configuration.DeliveryNoteFileName);
                        stream = printerManager.PrepareDeliveryNotePrintData(id, path, termsManager);
                    }
                    break;
                default:
                    throw new NotImplementedException();
            }

            stream.Position = 0;
            var result = new StreamActionResult(stream);

            if (report == PrintTypes.DeliveryNote)
            {
                result.ContentType = "application/pdf";
                path = "DeliveryNote.pdf";
            }
            else
            {
                result.ContentType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
            }

            result.ContentDisposition = new ContentDispositionHeaderValue("attachment") { FileName = Path.GetFileName(path) };

            return result;
		}
    }
}
