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
    [AuthorizeByPermissions(PermissionTypes = new[] { Permissions.Orders })]
    public partial class PositionSearchController : ReadOnlyClientApiController<PositionsModel, SearchPositionView, int, ISearchPositionViewManager>
    {
        public IProductsManager ProductManager { get; set; }
        public IMaterialsManager MaterialManager { get; set; }

        public PositionSearchController(ISearchPositionViewManager manager, IProductsManager productsManager, IMaterialsManager materialManager) : 
            base(manager)
        {
            this.ProductManager = productsManager;
            this.MaterialManager = materialManager;
        }

        protected override void EntityToModel(SearchPositionView entity, PositionsModel model)
        {
            model.orderId = entity.OrderId;
            model.isMaterialPosition = entity.IsMaterialPosition;
            model.productId = entity.ProductId;
            model.materialId = entity.MaterialId;
            model.isAlternative = entity.IsAlternative;
            model.paymentType = entity.PaymentType;
            model.paymentTypeString = entity.PaymentTypeString;
            model.parentId = entity.ParentId;
            model.amount = entity.RestAmount ?? 0;
            model.price = entity.Price;
            model.priceString = entity.Price.ToString();
            model.description = entity.Description;

            model.number = entity.Number;
            model.amountType = entity.ProductAmountTypeString;
            model.totalPrice = CalculationHelper.CalculatePositionPrice(entity.Price, entity.Amount, entity.Payment).ToString("N2") + " EUR";

            model.createDate = ((ISystemFields)entity).CreateDate;
            model.changeDate = ((ISystemFields)entity).ChangeDate;
        }
    }
}
