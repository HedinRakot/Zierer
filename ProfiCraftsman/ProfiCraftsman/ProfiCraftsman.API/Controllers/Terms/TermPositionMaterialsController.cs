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
    public partial class TermPositionMaterialsController : ClientApiController<TermPositionMaterialModel, TermPositionMaterialRsp, int, ITermPositionMaterialRspManager>
    {

        public TermPositionMaterialsController(ITermPositionMaterialRspManager manager) : base(manager) { }

        protected override void EntityToModel(TermPositionMaterialRsp entity, TermPositionMaterialModel model)
        {
            model.termPositionId = entity.TermPositionId;
            model.materialId = entity.MaterialId;
            model.materialName = entity.Materials.Name;
            model.amount = entity.Amount;
            model.createDate = ((ISystemFields)entity).CreateDate;
            model.changeDate = ((ISystemFields)entity).ChangeDate;
        }

        protected override void ModelToEntity(TermPositionMaterialModel model, TermPositionMaterialRsp entity, ActionTypes actionType)
        {
            entity.TermPositionId = model.termPositionId;
            entity.MaterialId = model.materialId;
            entity.Amount = model.amount;
        }
    }
}
