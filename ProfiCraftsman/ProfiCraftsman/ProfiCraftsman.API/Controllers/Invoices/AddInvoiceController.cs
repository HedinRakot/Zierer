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
using System.Linq;
using System.Web.Http;

namespace ProfiCraftsman.API.Controllers.Invoices
{
    [AuthorizeByPermissions(PermissionTypes = new[] { Permissions.Invoices })]
    public partial class AddInvoicesController : ApiController
    {
        protected readonly IInvoicesManager invoicesManager;
        protected readonly IUniqueNumberProvider numberProvider;
        protected readonly IOrdersManager ordersManager;
        protected readonly ITaxesManager taxesManager;
        protected readonly IInvoicePositionsManager invoicePositionsManager;
        protected readonly ITermPositionsManager termPositionsManager;
        protected readonly IPositionsManager positionsManager;
        protected readonly ITermCostsManager termCostsManager;

        public AddInvoicesController(IInvoicesManager invoicesManager, IOrdersManager ordersManager,
            ITaxesManager taxesManager, IInvoicePositionsManager invoicePositionsManager, IUniqueNumberProvider numberProvider,
            ITermPositionsManager termPositionsManager, IPositionsManager positionsManager, ITermCostsManager termCostsManager)
        {
            this.invoicesManager = invoicesManager;
            this.numberProvider = numberProvider;
            this.ordersManager = ordersManager;
            this.taxesManager = taxesManager;
            this.invoicePositionsManager = invoicePositionsManager;
            this.termPositionsManager = termPositionsManager;
            this.positionsManager = positionsManager;
            this.termCostsManager = termCostsManager;
        }

        public IHttpActionResult Post(AddInvoiceModel model)
        {
            var order = ordersManager.GetById(model.orderId);
            double taxValue = CalculationHelper.CalculateTaxes(taxesManager);

            var invoice = new ProfiCraftsman.Contracts.Entities.Invoices()
            {
                Orders = order,
                TaxValue = taxValue,
                WithTaxes = order.Customers.WithTaxes,
                Discount = order.Discount ?? 0,
                CreateDate = DateTime.Now,
                ChangeDate = DateTime.Now,
                IsSellInvoice = model.isSell,
                PayInDays = 10,
                InvoicePositions = new List<InvoicePositions>()
            };


            //if (AddInvoicePositions(model.isMonthlyInvoice, model.isSell, order, invoice))
            if (AddInvoicePositions(order, invoice))
            {
                invoice.InvoiceNumber = numberProvider.GetNextInvoiceNumber();

                invoicesManager.AddEntity(invoice);
                invoicesManager.SaveChanges();
            }

            model.Id = invoice.Id;
            return Ok(model);
        }

        //protected bool AddInvoicePositions(bool isMonthlyInvoice, bool isSell, Orders order, Contracts.Entities.Invoices invoice)
        //{
        //    var orderPositions = order.Positions.Where(o => !o.DeleteDate.HasValue && (o.ProductId.HasValue || o.MaterialId.HasValue)).ToList();

        //    var allInvoicePositions = invoicePositionsManager.GetEntities(o => o.Positions.OrderId == order.Id && !o.DeleteDate.HasValue).ToList();

        //    bool hasOpenPositions = false;

        //    foreach (var orderPosition in orderPositions)
        //    {
        //        var invoicePositions = allInvoicePositions.Where(o => o.PositionId == orderPosition.Id);
        //        var amount = 0;

        //        var oldAmount = invoicePositions.Sum(o => o.Amount);

        //        if (oldAmount == 0)
        //        {
        //            if (!isMonthlyInvoice)
        //            {
        //                amount = orderPosition.Amount;
        //            }
        //        }
        //        else if (orderPosition.Amount > oldAmount)
        //        {
        //            amount = orderPosition.Amount - oldAmount;
        //        }

        //        //if (orderPosition.Materials != null)
        //        //{
        //        //    var oldAmount = invoicePositions.Sum(o => o.Amount);

        //        //    if (oldAmount == 0)
        //        //    {
        //        //        if (!isMonthlyInvoice)
        //        //        {
        //        //            amount = orderPosition.Amount;
        //        //        }
        //        //    }
        //        //    else if (orderPosition.Amount > oldAmount)
        //        //    {
        //        //        amount = orderPosition.Amount - oldAmount;
        //        //    }
        //        //}
        //        //else if (orderPosition.Products != null)
        //        //{
        //        //    amount = 1;

        //        //    //GetPeriod(isMonthlyInvoice, order, orderPosition, invoicePositions, ref amount);
        //        //}

        //        if (amount != 0)
        //        {
        //            //if (isSell && orderPosition.Products != null && 
        //            //    !orderPosition.Products.IsVirtual)
        //            //{
        //            //    orderPosition.Products.IsSold = true;
        //            //}

        //            var newPosition = new InvoicePositions()
        //            {
        //                Positions = orderPosition,
        //                Invoices = invoice,
        //                Price = orderPosition.Price,
        //                Amount = amount,
        //                CreateDate = DateTime.Now,
        //                ChangeDate = DateTime.Now,
        //                PaymentType = orderPosition.PaymentType
        //            };
        //            invoice.InvoicePositions.Add(newPosition);
        //            hasOpenPositions = true;
        //        }
        //    }

        //    return hasOpenPositions;
        //}

        protected bool AddInvoicePositions(Orders order, Contracts.Entities.Invoices invoice)
        {
            var result = false;
            //todo var allInvoicePositions = invoicePositionsManager.GetEntities(o => o.Positions.OrderId == order.Id && !o.DeleteDate.HasValue).ToList();

            //TODO discuss with customer - take positions where proccessed amount not null (but take with 0)
            var termPositions = termPositionsManager.GetEntities(o => !o.DeleteDate.HasValue && o.Terms.OrderId == order.Id && o.ProccessedAmount.HasValue).ToList();

            foreach (var termPosition in termPositions)
            {
                //positions
                if (termPosition.ProccessedAmount.Value > 0)
                {
                    var newPosition = new InvoicePositions()
                    {
                        Positions = termPosition.Positions,
                        Invoices = invoice,
                        Price = termPosition.Positions.Price,
                        Amount = termPosition.ProccessedAmount.Value,
                        CreateDate = DateTime.Now,
                        ChangeDate = DateTime.Now,
                        PaymentType = termPosition.Positions.PaymentType
                    };

                    invoice.InvoicePositions.Add(newPosition);
                    result = true;
                }

                //materials
                foreach (var material in termPosition.TermPositionMaterialRsps.Where(o => !o.DeleteDate.HasValue && o.Amount.HasValue))
                {
                    var amount = material.Amount.Value;
                    if (material.Materials.MaterialAmountTypes == MaterialAmountTypes.Meter)
                    {
                        if (material.Materials.Length != 0)
                        {
                            amount = amount / (double)material.Materials.Length.Value;
                        }
                        else
                        {
                            //todo
                        }
                    }

                    var newPosition = new InvoicePositions()
                    {
                        TermPositionMaterialId = material.Id,
                        Invoices = invoice,
                        Price = material.Materials.Price,
                        Amount = amount,
                        CreateDate = DateTime.Now,
                        ChangeDate = DateTime.Now,
                        PaymentType = (int)PaymentTypes.Standard
                    };

                    invoice.InvoicePositions.Add(newPosition);
                    result = true;
                }
            }

            //material positions without terms
            var materialPositionsWithoutTerms = positionsManager.GetEntities(o => o.OrderId == order.Id && !o.DeleteDate.HasValue &&
                !o.TermId.HasValue && o.MaterialId.HasValue && o.IsMaterialPosition).ToList();
            foreach (var position in materialPositionsWithoutTerms)
            {
                var newPosition = new InvoicePositions()
                {
                    Positions = position,
                    Invoices = invoice,
                    Price = position.Materials.Price,
                    Amount = position.Amount,
                    CreateDate = DateTime.Now,
                    ChangeDate = DateTime.Now,
                    PaymentType = (int)PaymentTypes.Standard
                };

                invoice.InvoicePositions.Add(newPosition);
                result = true;
            }

            //extra costs
            var termCosts = termCostsManager.GetEntities(o => !o.DeleteDate.HasValue && o.Terms.OrderId == order.Id).ToList();
            foreach (var termCost in termCosts)
            {
                var newPosition = new InvoicePositions()
                {
                    TermCosts = termCost,
                    Invoices = invoice,
                    Price = termCost.Price,
                    Amount = 1,
                    CreateDate = DateTime.Now,
                    ChangeDate = DateTime.Now,
                    PaymentType = (int)PaymentTypes.Standard
                };

                invoice.InvoicePositions.Add(newPosition);
                result = true;
            }

            return result;
        }
    }
}
