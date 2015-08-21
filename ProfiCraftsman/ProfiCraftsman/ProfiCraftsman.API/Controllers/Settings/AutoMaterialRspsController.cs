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

namespace ProfiCraftsman.API.Controllers.Settings
{
    /// <summary>
    ///     Controller for <see cref="AutoMaterialRsp"/> entity
    /// </summary>
    public partial class AutoMaterialRspsController : ClientApiController<AutoMaterialRspModel, AutoMaterialRsp, int, IAutoMaterialRspManager>
    {

        public AutoMaterialRspsController(IAutoMaterialRspManager manager) : base(manager) { }

        protected override void EntityToModel(AutoMaterialRsp entity, AutoMaterialRspModel model)
        {
            model.autoId = entity.AutoId;
            model.materialId = entity.MaterialId;
            model.amount = entity.Amount;
            model.mustCount = entity.Materials.MustCount;
            model.createDate = ((ISystemFields)entity).CreateDate;
            model.changeDate = ((ISystemFields)entity).ChangeDate;
        }
        protected override void ModelToEntity(AutoMaterialRspModel model, AutoMaterialRsp entity, ActionTypes actionType)
        {
            entity.AutoId = model.autoId;
            entity.MaterialId = model.materialId;
            entity.Amount = model.amount;
        }
    }
}
