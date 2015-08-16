using ProfiCraftsman.API.Models;
using ProfiCraftsman.API.Models.Invoices;
using ProfiCraftsman.API.Security;
using ProfiCraftsman.Contracts;
using ProfiCraftsman.Contracts.Entities;
using ProfiCraftsman.Contracts.Enums;
using ProfiCraftsman.Contracts.Managers;
using ProfiCraftsman.Contracts.Services;
using ProfiCraftsman.Lib.Managers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;

namespace ProfiCraftsman.API.Controllers.Invoices
{
    public partial class GenerateMonthInvoicesController: AddInvoicesController
    {
        public GenerateMonthInvoicesController(IInvoicesManager invoicesManager, IOrdersManager ordersManager,
            ITaxesManager taxesManager, IInvoicePositionsManager invoicePositionsManager, IUniqueNumberProvider numberProvider) : 
            base(invoicesManager, ordersManager, taxesManager, invoicePositionsManager, numberProvider)
        {
        }

        [HttpGet]
        public HttpResponseMessage Get()
        {
            double taxValue = CalculationHelper.CalculateTaxes(taxesManager);
            var invoicesForCurrentMonth = new List<ProfiCraftsman.Contracts.Entities.Invoices>();

            var orders = ordersManager.GetEntities(o => 
                !o.DeleteDate.HasValue && 
                o.OrderStatus == OrderStatusTypes.Open && 
                !o.IsOffer &&
                o.AutoBill).ToList();

            foreach (var order in orders)
            {
                var isSell = false;//TODO need generate for Sell positions monthly orders

                var invoice = new ProfiCraftsman.Contracts.Entities.Invoices()
                {
                    Orders = order,
                    TaxValue = taxValue,
                    WithTaxes = order.Customers.WithTaxes,
                    Discount = order.Discount ?? 0,
                    CreateDate = DateTime.Now,
                    ChangeDate = DateTime.Now,
                    IsSellInvoice = isSell,
                    InvoicePositions = new List<InvoicePositions>()
                };
                
                if (AddInvoicePositions(true, isSell, order, invoice))
                {
                    invoice.InvoiceNumber = numberProvider.GetNextInvoiceNumber();

                    invoicesManager.AddEntity(invoice);
                    invoicesManager.SaveChanges();
                }

                invoicesForCurrentMonth.AddRange(order.Invoices.
                    Where(o => o.CreateDate.Month == DateTime.Now.Month && o.CreateDate.Year == DateTime.Now.Year).ToList());
            }

            var response = new HttpResponseMessage(HttpStatusCode.OK);

            var dataDirectory = Path.Combine(HttpRuntime.AppDomainAppPath, "App_Data");
            string path = Path.Combine(dataDirectory, Contracts.Configuration.InvoiceFileName);

            var stream = ordersManager.PrepareMonthInvoicePrintData(invoicesForCurrentMonth, path, invoicesManager, taxesManager);
            
            response.Content = new StreamContent(stream);
            response.Content.Headers.ContentType =
                new MediaTypeHeaderValue("application/vnd.openxmlformats-officedocument.wordprocessingml.document");

            return response;
        }
    }
}
