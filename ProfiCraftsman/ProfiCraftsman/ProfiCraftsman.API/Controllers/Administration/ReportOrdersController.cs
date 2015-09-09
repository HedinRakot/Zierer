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

namespace ProfiCraftsman.API.Controllers
{
    /// <summary>
    ///     Controller for <see cref="Orders"/> entity
    /// </summary>
    [AuthorizeByPermissions(PermissionTypes = new[] { Permissions.ReportOrders })]    
    public partial class ReportOrdersController: ReadOnlyClientApiController<ReportOrdersModel, Orders, int, IOrdersManager>
    {
        private readonly IAdditionalCostsManager additionalCostsManager;

        public ReportOrdersController(
            IOrdersManager manager,
            IAdditionalCostsManager additionalCostsManager)
            : base(manager)
        {
            this.additionalCostsManager = additionalCostsManager;
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
