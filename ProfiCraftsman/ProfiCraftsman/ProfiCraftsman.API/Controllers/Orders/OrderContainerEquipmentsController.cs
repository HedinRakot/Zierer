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
using CoreBase;
using CoreBase.Entities;
using CoreBase.Controllers;

namespace ProfiCraftsman.API.Controllers
{
    public partial class OrderProductEquipmentsController : ClientApiController<OrderProductMaterialModel, OrderProductMaterialRsp, int, IOrderProductMaterialRspManager>
    {

        public OrderProductEquipmentsController(IOrderProductMaterialRspManager manager) : base(manager) { }

        protected override void EntityToModel(OrderProductMaterialRsp entity, OrderProductMaterialModel model)
        {
            model.orderId = entity.OrderId;
            model.productId = entity.ProductId;
            model.materialId = entity.MaterialId;
            model.amount = entity.Amount;
            model.createDate = ((ISystemFields)entity).CreateDate;
            model.changeDate = ((ISystemFields)entity).ChangeDate;
        }

        protected override void ModelToEntity(OrderProductMaterialModel model, OrderProductMaterialRsp entity, ActionTypes actionType)
        {
            entity.OrderId = model.orderId;
            entity.ProductId = model.productId;
            entity.MaterialId = model.materialId;
            entity.Amount = model.amount;
        }
    }
}
