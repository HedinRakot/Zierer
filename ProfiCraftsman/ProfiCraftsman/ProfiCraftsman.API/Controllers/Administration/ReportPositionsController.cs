using CoreBase.Controllers;
using CoreBase.Entities;
using CoreBase.Exceptions;
using CoreBase.Models;
using ProfiCraftsman.API.Models;
using ProfiCraftsman.API.Models.Settings;
using ProfiCraftsman.API.Security;
using ProfiCraftsman.Contracts;
using ProfiCraftsman.Contracts.Entities;
using ProfiCraftsman.Contracts.Enums;
using ProfiCraftsman.Contracts.Managers;
using ProfiCraftsman.Lib.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Web.Http;

namespace ProfiCraftsman.API.Controllers
{
    /// <summary>
    ///     Controller for <see cref="Positions"/> entity
    /// </summary>
    [AuthorizeByPermissions(PermissionTypes = new[] { Permissions.ReportOrders })]
    public partial class ReportPositionsController: ReadOnlyClientApiController<ReportPositionsModel, Positions, int, IPositionsManager>
    {
        public IProductsManager ProductManager { get; set; }
        public IMaterialsManager MaterialManager { get; set; }

        public ReportPositionsController(IPositionsManager manager, IProductsManager productsManager, IMaterialsManager materialManager) : 
            base(manager)
        {
            this.ProductManager = productsManager;
            this.MaterialManager = materialManager;
        }

        protected override void EntityToModel(Positions entity, ReportPositionsModel model)
        {
            model.orderId = entity.OrderId;
            model.paymentType = entity.PaymentType;
            model.paymentTypeString = entity.PaymentTypeString;
            model.amount = entity.Amount;
            model.amountString = entity.Amount.ToString();
            model.price = entity.Price;
            model.priceString = entity.Price.ToString();
            model.description = entity.Description;
            model.createDate = ((ISystemFields)entity).CreateDate;
            model.changeDate = ((ISystemFields)entity).ChangeDate;

            if (entity.ProductId.HasValue)
            {
                model.number = entity.Products.Number;
                model.amountType = entity.Products.ProductAmountTypeString;
                model.totalPrice = CalculationHelper.CalculatePositionPrice(entity.Price, entity.Amount, entity.Payment).ToString("N2") + " EUR";
            }
            else if (entity.MaterialId.HasValue)
            {
                model.number = entity.Materials.Number;
                model.amountType = entity.Materials.MaterialAmountTypeString;
                model.totalPrice = CalculationHelper.CalculatePositionPrice(entity.Price, entity.Amount, entity.Payment).ToString("N2") + " EUR";
            }
            else
            {
                model.number = "Gruppe";
                model.paymentTypeString = String.Empty;
                model.priceString = String.Empty;
                model.amountString = String.Empty;
            }
        }        

        protected override string BuildWhereClause<T>(Filter filter)
        {
            if (filter.Field == "hasParent")
            {
                var hasParent = Boolean.Parse(filter.Value);

                return String.Format("ParentId.HasValue == {0}", hasParent);
            }

            if (filter.Field == "onlyProducts")
            {
                //var isGroup = Boolean.Parse(filter.Value);

                return String.Format("ProductId.HasValue");
            }

            return base.BuildWhereClause<T>(filter);
        }        
    }
}
