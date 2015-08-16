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
    public partial class OrderProductEquipmentsController : ClientApiController<OrderProductEquipmentModel, OrderProductEquipmentRsp, int, IOrderProductEquipmentRspManager>
    {

        public OrderProductEquipmentsController(IOrderProductEquipmentRspManager manager) : base(manager) { }

        protected override void EntityToModel(OrderProductEquipmentRsp entity, OrderProductEquipmentModel model)
        {
            model.orderId = entity.OrderId;
            model.productId = entity.ProductId;
            model.equipmentId = entity.EquipmentId;
            model.amount = entity.Amount;
            model.createDate = ((ISystemFields)entity).CreateDate;
            model.changeDate = ((ISystemFields)entity).ChangeDate;
        }

        protected override void ModelToEntity(OrderProductEquipmentModel model, OrderProductEquipmentRsp entity, ActionTypes actionType)
        {
            entity.OrderId = model.orderId;
            entity.ProductId = model.productId;
            entity.EquipmentId = model.equipmentId;
            entity.Amount = model.amount;
        }
    }
}
