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
            model.isMaterialPosition = entity.IsMaterialPosition;
            model.productId = entity.ProductId;
            model.materialId = entity.MaterialId;
            model.isAlternative = entity.IsAlternative;
            model.paymentType = entity.PaymentType;

            if (entity.ProductId.HasValue)
            {
                model.description = entity.Products.Name;
                model.number = entity.Products.Number;
            }
            else if (entity.MaterialId.HasValue)
            {
                model.description = entity.Materials.Name;
                model.number = entity.Materials.Number;
            }

            model.amount = entity.Amount;
            model.price = entity.Price;
            model.createDate = ((ISystemFields)entity).CreateDate;
            model.changeDate = ((ISystemFields)entity).ChangeDate;
        }

        protected override void ModelToEntity(PositionsModel model, Positions entity, ActionTypes actionType)
        {
            entity.OrderId = model.orderId;
            entity.IsMaterialPosition = model.isMaterialPosition;
            entity.ProductId = model.productId;
            entity.MaterialId = model.materialId;
            entity.Price = model.price;
            entity.IsAlternative = model.isAlternative;
            entity.PaymentType = model.paymentType;

            if(actionType == ActionTypes.Add && model.productId.HasValue)
            {
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
