using CoreBase.Controllers;
using CoreBase.Entities;
using ProfiCraftsman.API.Models;
using ProfiCraftsman.API.Models.Settings;
using ProfiCraftsman.API.Security;
using ProfiCraftsman.Contracts;
using ProfiCraftsman.Contracts.Entities;
using ProfiCraftsman.Contracts.Enums;
using ProfiCraftsman.Contracts.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;

namespace ProfiCraftsman.API.Controllers
{
    /// <summary>
    ///     Controller for <see cref="Positions"/> entity
    /// </summary>
    [AuthorizeByPermissions(PermissionTypes = new[] { Permissions.Orders })]
    public partial class PositionsController: ClientApiController<PositionsModel, Positions, int, IPositionsManager>
    {
        public IOrderProductMaterialRspManager OrderProductMaterialRspManager { get; set; }
        public IProductsManager ProductManager { get; set; }

        public PositionsController(IPositionsManager manager, IOrderProductMaterialRspManager orderProductMaterialRspManager,
            IProductsManager productsManager) : 
            base(manager)
        {
            this.OrderProductMaterialRspManager = orderProductMaterialRspManager;
            this.ProductManager = productsManager;
        }

        protected override void EntityToModel(Positions entity, PositionsModel model)
        {
            model.orderId = entity.OrderId;
            model.isSellOrder = entity.IsSellOrder;
            model.productId = entity.ProductId;
            model.isMain = entity.IsMain;
            model.paymentType = entity.PaymentType;

            if (entity.ProductId.HasValue)
            {
                model.description = String.Format("{0} {1}", entity.Products.Number, entity.Products.ProductTypes.Name);

                if(entity.FromDate != DateTime.MinValue)
                    model.fromDate = entity.FromDate;

                if (entity.ToDate != DateTime.MinValue)
                    model.toDate = entity.ToDate;
            }

            model.additionalCostId = entity.AdditionalCostId;

            if (entity.AdditionalCostId.HasValue)
            {
                model.description = entity.AdditionalCosts.Name;
            }

            model.amount = entity.Amount;
            model.price = entity.Price;
            model.createDate = ((ISystemFields)entity).CreateDate;
            model.changeDate = ((ISystemFields)entity).ChangeDate;

            model.isOffer = entity.Orders.IsOffer;
        }

        protected override void ModelToEntity(PositionsModel model, Positions entity, ActionTypes actionType)
        {
            entity.OrderId = model.orderId;
            entity.IsSellOrder = model.isSellOrder;
            entity.ProductId = model.productId;
            entity.AdditionalCostId = model.additionalCostId;
            entity.Price = model.price;
            entity.IsMain = model.isMain;
            entity.PaymentType = model.paymentType;

            if (model.productId.HasValue)
                entity.Amount = 1;
            else
                entity.Amount = model.amount;

            if(actionType == ActionTypes.Add && model.productId.HasValue)
            {
                entity.FromDate = model.fromDate.HasValue ? model.fromDate.Value.Date : DateTime.Now.Date;
                entity.ToDate = model.toDate.HasValue ? model.toDate.Value.Date : DateTime.Now.Date;

                var product = ProductManager.GetById(model.productId.Value);
                foreach (var material in product.ProductMaterialRsps)
                {
                    OrderProductMaterialRspManager.AddEntity(new OrderProductMaterialRsp()
                    {
                        Amount = material.Amount,
                        ProductId = model.productId.Value,
                        OrderId = model.orderId,
                        MaterialId = material.MaterialId
                    });
                }
            }
        }
    }
}
