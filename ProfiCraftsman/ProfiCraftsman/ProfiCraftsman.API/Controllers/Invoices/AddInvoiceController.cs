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



            if (AddInvoicePositions(order, invoice))
            {
                invoice.InvoiceNumber = numberProvider.GetNextInvoiceNumber();

                invoicesManager.AddEntity(invoice);
                invoicesManager.SaveChanges();
            }

            model.Id = invoice.Id;
            return Ok(model);
        }

        protected bool AddInvoicePositions(Orders order, Contracts.Entities.Invoices invoice)
        {
            var result = false;

            var allInvoicePositions = invoicePositionsManager.GetEntities(o => !o.DeleteDate.HasValue && 
                ((o.PositionId.HasValue && o.Positions.OrderId == order.Id) || (o.TermCostId.HasValue && o.TermCosts.Terms.OrderId == order.Id) ||
                 (o.TermPositionMaterialId.HasValue && o.TermPositionMaterialRsp.TermPositions.Terms.OrderId == order.Id))
                ).ToList();

            //TODO discuss with customer - take positions where proccessed amount not null (but take with 0)
            var termPositions = termPositionsManager.GetEntities(o => !o.DeleteDate.HasValue && o.Terms.OrderId == order.Id && o.ProccessedAmount.HasValue).ToList();

            foreach (var termPosition in termPositions)
            {
                var invoicePositions = allInvoicePositions.Where(o => o.PositionId.HasValue && o.PositionId.Value == termPosition.PositionId).ToList();

                double amount = 0;
                var oldAmount = invoicePositions.Sum(o => o.Amount);
                double usedAmount = termPositions.Where(o => o.PositionId == termPosition.PositionId).Sum(o => o.ProccessedAmount.Value);
                if (oldAmount == 0)
                {
                    amount = usedAmount;
                }
                else if (usedAmount > oldAmount)
                {
                    amount = usedAmount - oldAmount;
                }

                //positions
                if (amount > 0)
                {
                    var newPosition = new InvoicePositions()
                    {
                        PositionId = termPosition.PositionId,
                        Invoices = invoice,
                        Price = termPosition.Positions.Price,
                        Amount = amount,
                        CreateDate = DateTime.Now,
                        ChangeDate = DateTime.Now,
                        PaymentType = termPosition.Positions.PaymentType
                    };

                    invoice.InvoicePositions.Add(newPosition);

                    allInvoicePositions.Add(newPosition);

                    result = true;
                }

                //materials
                foreach (var material in termPosition.TermPositionMaterialRsps.Where(o => !o.DeleteDate.HasValue && o.Amount.HasValue))
                {
                    invoicePositions = allInvoicePositions.
                        Where(o => o.TermPositionMaterialId.HasValue && o.TermPositionMaterialId.Value == material.Id).ToList();


                    //old amount
                    oldAmount = invoicePositions.Sum(o => o.Amount);
                    //used amount
                    usedAmount = material.Amount.Value;

                    if (material.Materials.MaterialAmountTypes == MaterialAmountTypes.Meter)
                    {
                        if (material.Materials.Length != 0)
                        {
                            usedAmount = usedAmount / (double)material.Materials.Length.Value;
                        }
                        else
                        {
                            //todo
                        }
                    }


                    amount = 0;
                    if (oldAmount == 0)
                    {
                        amount = usedAmount;
                    }
                    else if (usedAmount > oldAmount)
                    {
                        amount = usedAmount - oldAmount;
                    }


                    if (amount > 0)
                    {
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
            }

            //material positions without terms
            var materialPositionsWithoutTerms = positionsManager.GetEntities(o => o.OrderId == order.Id && !o.DeleteDate.HasValue &&
                !o.TermId.HasValue && o.MaterialId.HasValue && o.IsMaterialPosition).ToList();
            foreach (var position in materialPositionsWithoutTerms)
            {
                var invoicePositions = allInvoicePositions.
                        Where(o => o.PositionId.HasValue && o.PositionId.Value == position.Id).ToList();

                double amount = 0;
                //old amount
                var oldAmount = invoicePositions.Sum(o => o.Amount);
                double usedAmount = position.Amount;

                if (oldAmount == 0)
                {
                    amount = usedAmount;
                }
                else if (usedAmount > oldAmount)
                {
                    amount = usedAmount - oldAmount;
                }

                if (amount > 0)
                {
                    var newPosition = new InvoicePositions()
                    {
                        Positions = position,
                        Invoices = invoice,
                        Price = position.Materials.Price,
                        Amount = amount,
                        CreateDate = DateTime.Now,
                        ChangeDate = DateTime.Now,
                        PaymentType = (int)PaymentTypes.Standard
                    };

                    invoice.InvoicePositions.Add(newPosition);
                    result = true;
                }
            }

            //extra costs
            var termCosts = termCostsManager.GetEntities(o => !o.DeleteDate.HasValue && o.Terms.OrderId == order.Id).ToList();
            foreach (var termCost in termCosts)
            {
                var invoicePositions = allInvoicePositions.
                        Where(o => o.TermCostId.HasValue && o.TermCostId.Value == termCost.Id).ToList();

                double amount = 0;
                //old amount
                var oldAmount = invoicePositions.Sum(o => o.Amount);
                if (oldAmount == 0)
                {
                    amount = 1;
                }

                if (amount > 0)
                {
                    var newPosition = new InvoicePositions()
                    {
                        TermCosts = termCost,
                        Invoices = invoice,
                        Price = termCost.Price,
                        Amount = amount,
                        CreateDate = DateTime.Now,
                        ChangeDate = DateTime.Now,
                        PaymentType = (int)PaymentTypes.Standard
                    };

                    invoice.InvoicePositions.Add(newPosition);
                    result = true;
                }

            }

            return result;
        }
    }
}
