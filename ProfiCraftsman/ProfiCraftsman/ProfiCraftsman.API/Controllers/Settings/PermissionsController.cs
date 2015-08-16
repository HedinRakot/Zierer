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
    [AuthorizeByPermissions(PermissionTypes = new[] { Permissions.Permission })]
    /// <summary>
    ///     Controller for <see cref="Permission"/> entity
    /// </summary>
    public partial class PermissionsController: ClientApiController<PermissionModel, Permission, int, IPermissionManager>
    {

        public PermissionsController(IPermissionManager manager): base(manager){}

        protected override void EntityToModel(Permission entity, PermissionModel model)
        {
            model.name = entity.Name;
            model.description = entity.Description;
            model.createDate = ((ISystemFields)entity).CreateDate;
            model.changeDate = ((ISystemFields)entity).ChangeDate;
        }
        protected override void ModelToEntity(PermissionModel model, Permission entity, ActionTypes actionType)
        {
            entity.Name = model.name;
            entity.Description = model.description;
        }
    }
}
