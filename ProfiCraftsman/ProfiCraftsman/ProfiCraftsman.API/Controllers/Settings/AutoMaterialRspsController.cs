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
using System.Linq;

namespace ProfiCraftsman.API.Controllers.Settings
{
    /// <summary>
    ///     Controller for <see cref="AutoMaterialRsp"/> entity
    /// </summary>
    public partial class AutoMaterialRspsController : ClientApiController<AutoMaterialRspModel, AutoMaterialRsp, int, IAutoMaterialRspManager>
    {
        protected IWarehouseMaterialsManager warehouseMaterialsManager;

        public AutoMaterialRspsController(IAutoMaterialRspManager manager, IWarehouseMaterialsManager warehouseMaterialsManager) : base(manager)
        {
            this.warehouseMaterialsManager = warehouseMaterialsManager;
            ActionSuccess += ClientBaseController_ActionSuccess;
        }

        private void ClientBaseController_ActionSuccess(object sender, ActionSuccessEventArgs<AutoMaterialRsp, int> e)
        {
            if (e.ActionType == ActionTypes.Delete)
            {
                var newAmount = e.Entity.Amount;

                var warehouseMaterial = warehouseMaterialsManager.GetEntities(o => !o.DeleteDate.HasValue && o.MaterialId == e.Entity.MaterialId).FirstOrDefault();
                if (warehouseMaterial != null)
                {
                    warehouseMaterial.IsAmount += newAmount;
                    warehouseMaterialsManager.SaveChanges();
                }
            }
        }

        protected override void EntityToModel(AutoMaterialRsp entity, AutoMaterialRspModel model)
        {
            model.autoId = entity.AutoId;
            model.materialId = entity.MaterialId;
            model.materialName = entity.Materials.Name;
            model.amount = entity.Amount;
            model.mustCount = entity.Materials.MustCount;
            model.createDate = ((ISystemFields)entity).CreateDate;
            model.changeDate = ((ISystemFields)entity).ChangeDate;
        }

        protected override void ModelToEntity(AutoMaterialRspModel model, AutoMaterialRsp entity, ActionTypes actionType)
        {
            entity.AutoId = model.autoId;
            entity.MaterialId = model.materialId;

            if (entity.Amount != model.amount)
            {
                var newAmount = model.amount - entity.Amount;

                var warehouseMaterial = warehouseMaterialsManager.GetEntities(o => !o.DeleteDate.HasValue && o.MaterialId == model.materialId).FirstOrDefault();
                if(warehouseMaterial != null)
                {
                    warehouseMaterial.IsAmount -= newAmount;
                }

                entity.Amount = model.amount;
            }
        }
    }
}
