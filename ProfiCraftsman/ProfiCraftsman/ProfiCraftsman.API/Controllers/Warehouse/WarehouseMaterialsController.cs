using CoreBase.Controllers;
using CoreBase.Entities;
using ProfiCraftsman.API.Models;
using ProfiCraftsman.API.Models.Settings;
using ProfiCraftsman.API.Models.Warehouse;
using ProfiCraftsman.API.Security;
using ProfiCraftsman.Contracts;
using ProfiCraftsman.Contracts.Entities;
using ProfiCraftsman.Contracts.Enums;
using ProfiCraftsman.Contracts.Managers;
using System;

namespace ProfiCraftsman.API.Controllers.Settings
{
    /// <summary>
    ///     Controller for <see cref="WarehouseMaterials"/> entity
    /// </summary>
    public partial class WarehouseMaterialsController : ClientApiController<WarehouseMaterialModel, WarehouseMaterials, int, IWarehouseMaterialsManager>
    {

        public WarehouseMaterialsController(IWarehouseMaterialsManager manager) : base(manager) { }

        protected override void EntityToModel(WarehouseMaterials entity, WarehouseMaterialModel model)
        {
            model.materialId = entity.MaterialId;
            model.isAmount = entity.IsAmount;
            model.mustAmount = entity.MustAmount;
            model.createDate = ((ISystemFields)entity).CreateDate;
            model.changeDate = ((ISystemFields)entity).ChangeDate;
        }
        protected override void ModelToEntity(WarehouseMaterialModel model, WarehouseMaterials entity, ActionTypes actionType)
        {
            entity.MaterialId = model.materialId;
            entity.IsAmount = model.isAmount;
            entity.MustAmount = model.mustAmount;
        }
    }
}
