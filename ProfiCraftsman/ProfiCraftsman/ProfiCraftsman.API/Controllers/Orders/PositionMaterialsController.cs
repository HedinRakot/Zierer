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
    public partial class PositionMaterialsController : ClientApiController<OrderProductMaterialModel, PositionMaterialRsp, int, IPositionMaterialRspManager>
    {

        public PositionMaterialsController(IPositionMaterialRspManager manager) : base(manager) { }

        protected override void EntityToModel(PositionMaterialRsp entity, OrderProductMaterialModel model)
        {
            model.positionId = entity.PositionId;
            model.materialId = entity.MaterialId;
            model.amount = entity.Amount;
            model.createDate = ((ISystemFields)entity).CreateDate;
            model.changeDate = ((ISystemFields)entity).ChangeDate;
        }

        protected override void ModelToEntity(OrderProductMaterialModel model, PositionMaterialRsp entity, ActionTypes actionType)
        {
            entity.PositionId = model.positionId;
            entity.MaterialId = model.materialId;
            entity.Amount = model.amount;
        }
    }
}
