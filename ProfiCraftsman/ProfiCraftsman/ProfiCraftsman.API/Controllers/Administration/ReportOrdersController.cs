using System;
using ProfiCraftsman.API.Models;
using ProfiCraftsman.API.Security;
using ProfiCraftsman.Contracts;
using ProfiCraftsman.Contracts.Entities;
using ProfiCraftsman.Contracts.Enums;
using ProfiCraftsman.Contracts.Managers;
using ProfiCraftsman.Contracts.Services;
using System.Collections.Generic;
using System.Linq;
using CoreBase.Entities;
using CoreBase.Controllers;
using ProfiCraftsman.Lib.Managers;

namespace ProfiCraftsman.API.Controllers
{
    /// <summary>
    ///     Controller for <see cref="Orders"/> entity
    /// </summary>
    [AuthorizeByPermissions(PermissionTypes = new[] { Permissions.ReportOrders })]    
    public partial class ReportOrdersController: ReadOnlyClientApiController<ReportOrdersModel, Orders, int, IOrdersManager>
    {
        private ITermPositionsManager termPositionsManager { get; set; }
        private IPositionsManager positionsManager { get; set; }
        private ITermCostsManager termCostsManager { get; set; }
        private ITaxesManager taxesManager { get; set; }
        private IInvoicesManager invoicesManager { get; set; }

        public ReportOrdersController(IOrdersManager manager,
            ITermPositionsManager termPositionsManager, IPositionsManager positionsManager, ITermCostsManager termCostsManager, 
            ITaxesManager taxesManager, IInvoicesManager invoicesManager)
            : base(manager)
        {
            this.termPositionsManager = termPositionsManager;
            this.positionsManager = positionsManager;
            this.termCostsManager = termCostsManager;
            this.taxesManager = taxesManager;
            this.invoicesManager = invoicesManager;
        }
        
        protected override void EntityToModel(Orders entity, ReportOrdersModel model)
        {
            model.Id = entity.Id;
            model.street = entity.Street;
            model.zip = entity.Zip;
            model.city = entity.City;
            model.orderNumber = entity.OrderNumber;
            model.createDate = ((ISystemFields)entity).CreateDate;
            model.changeDate = ((ISystemFields)entity).ChangeDate;
            model.isOffer = entity.IsOffer;
            model.status = entity.Status;

            model.customerName = entity.CustomerName;
            model.communicationPartnerTitle = entity.CommunicationPartnerTitle;

            double profit = 0;
            model.totalPrice = CalculationHelper.CalculateTotalPrice(entity.Id, 
                termPositionsManager, positionsManager, termCostsManager, taxesManager, Manager,
                ref profit).ToString("N2") + " EUR";

            var invoices = invoicesManager.GetEntities(o => !o.DeleteDate.HasValue && o.OrderId == entity.Id).ToList();
            double totalInvoicesSum = 0;
            foreach (var invoice in invoices)
            {
                double totalPriceWithoutDiscountWithoutTax = 0;
                double totalPriceWithoutTax = 0;
                double totalPrice = 0;
                double summaryPrice = 0;

                CalculationHelper.CalculateInvoicePrices(invoice, out totalPriceWithoutDiscountWithoutTax,
                    out totalPriceWithoutTax, out totalPrice, out summaryPrice);

                totalInvoicesSum += summaryPrice;
            }

            model.totalInvoicesSum = totalInvoicesSum.ToString("N2") + " EUR";

            model.totalPayedSum = entity.Invoices.Where(o => !o.DeleteDate.HasValue).SelectMany(o => o.InvoicePayments.Where(p => !p.DeleteDate.HasValue)).
                Sum(o => o.Amount).ToString("N2") + " EUR";

            model.totalProfit = profit.ToString("N2") + " EUR";
        }        

        protected override string BuildWhereClause<T>(Filter filter)
        {
            if (filter.Field == "name")
            {
                var clauses = new List<string>();

                clauses.AddRange(new[] { 
        				base.BuildWhereClause<T>(new Filter { Field = "Customers.Name", Operator = filter.Operator, Value = filter.Value }),
        				base.BuildWhereClause<T>(new Filter { Field = "OrderNumber", Operator = filter.Operator, Value = filter.Value }),
        				base.BuildWhereClause<T>(new Filter { Field = "Street", Operator = filter.Operator, Value = filter.Value }),
        				base.BuildWhereClause<T>(new Filter { Field = "City", Operator = filter.Operator, Value = filter.Value }),
        				base.BuildWhereClause<T>(new Filter { Field = "Zip", Operator = filter.Operator, Value = filter.Value }),
                    });

                return string.Join(" or ", clauses);
            }
            else if (filter.Field == "status")
            {
                var status = 1;
                Int32.TryParse(filter.Value, out status);

                return String.Format(" {0}",  status == 2 ? String.Format("status = {0}", status) : "1 = 1");
            }

            return base.BuildWhereClause<T>(filter);
        }

        protected override IQueryable<Orders> Sort(IQueryable<Orders> entities, Sorting sorting)
        {
            if (sorting.Field == "customerName")
            {
                if (sorting.Direction == "desc")
                    return entities.OrderByDescending(o => o.Customers.Name);
                else
                    return entities.OrderBy(o => o.Customers.Name);
            }
            else if (sorting.Field == "communicationPartnerTitle")
            {
                if (sorting.Direction == "desc")
                    return entities.OrderByDescending(o => o.CommunicationPartners.Name).
                        ThenByDescending(o => o.CommunicationPartners.FirstName);
                else
                    return entities.OrderBy(o => o.CommunicationPartners.Name).
                        ThenBy(o => o.CommunicationPartners.FirstName);
            }

            return base.Sort(entities, sorting);
        }        
    }
}
