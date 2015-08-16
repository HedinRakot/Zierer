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
    [AuthorizeByPermissions(PermissionTypes = new[] { Permissions.Equipments })]
    /// <summary>
    ///     Controller for <see cref="Equipments"/> entity
    /// </summary>
    public partial class EquipmentsController: ClientApiController<EquipmentsModel, Equipments, int, IEquipmentsManager>
    {

        public EquipmentsController(IEquipmentsManager manager): base(manager){}

        protected override void EntityToModel(Equipments entity, EquipmentsModel model)
        {
            model.description = entity.Description;
            model.createDate = ((ISystemFields)entity).CreateDate;
            model.changeDate = ((ISystemFields)entity).ChangeDate;
        }
        protected override void ModelToEntity(EquipmentsModel model, Equipments entity, ActionTypes actionType)
        {
            entity.Description = model.description;
        }
    }
}
