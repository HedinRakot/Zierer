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

        public ReportOrdersController(IOrdersManager manager,
            ITermPositionsManager termPositionsManager, IPositionsManager positionsManager, ITermCostsManager termCostsManager)
            : base(manager)
        {
            this.termPositionsManager = termPositionsManager;
            this.positionsManager = positionsManager;
            this.termCostsManager = termCostsManager;
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
            model.totalPrice = CalculateTotalPrice(entity.Id).ToString("N2") + " EUR";
        }

        protected double CalculateTotalPrice(int orderId)
        {
            double result = 0;

            //TODO discuss with customer - take positions where proccessed amount not null (but take with 0)
            var termPositions = termPositionsManager.GetEntities(o => !o.DeleteDate.HasValue && o.Terms.OrderId == orderId && o.ProccessedAmount.HasValue).ToList();

            foreach (var termPosition in termPositions)
            {
                //positions
                if (termPosition.ProccessedAmount.Value > 0)
                {
                    result += CalculationHelper.CalculatePositionPrice(termPosition.Positions.Price, termPosition.ProccessedAmount.Value,
                        termPosition.Positions.Payment);
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

                    result += CalculationHelper.CalculatePositionPrice(material.Materials.Price, amount, PaymentTypes.Standard);
                }
            }

            //material positions without terms
            var materialPositionsWithoutTerms = positionsManager.GetEntities(o => o.OrderId == orderId && !o.DeleteDate.HasValue &&
                !o.TermId.HasValue && o.MaterialId.HasValue && o.IsMaterialPosition).ToList();
            foreach (var position in materialPositionsWithoutTerms)
            {
                result += CalculationHelper.CalculatePositionPrice(position.Price, position.Amount, position.Payment);
            }

            //extra costs
            var termCosts = termCostsManager.GetEntities(o => !o.DeleteDate.HasValue && o.Terms.OrderId == orderId).ToList();
            foreach (var termCost in termCosts)
            {
                result += CalculationHelper.CalculatePositionPrice(termCost.Price, 1, PaymentTypes.Standard);
            }

            return result;
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
