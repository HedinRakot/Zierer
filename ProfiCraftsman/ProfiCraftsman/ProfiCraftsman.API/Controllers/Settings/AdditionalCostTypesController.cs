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
    [AuthorizeByPermissions(PermissionTypes = new[] { Permissions.AdditionalCostTypes })]
    /// <summary>
    ///     Controller for <see cref="AdditionalCostTypes"/> entity
    /// </summary>
    public partial class AdditionalCostTypesController: ClientApiController<AdditionalCostTypesModel, AdditionalCostTypes, int, IAdditionalCostTypesManager>
    {

        public AdditionalCostTypesController(IAdditionalCostTypesManager manager): base(manager){}

        protected override void EntityToModel(AdditionalCostTypes entity, AdditionalCostTypesModel model)
        {
            model.name = entity.Name;
            model.createDate = ((ISystemFields)entity).CreateDate;
            model.changeDate = ((ISystemFields)entity).ChangeDate;
        }
        protected override void ModelToEntity(AdditionalCostTypesModel model, AdditionalCostTypes entity, ActionTypes actionType)
        {
            entity.Name = model.name;
        }
    }
}
