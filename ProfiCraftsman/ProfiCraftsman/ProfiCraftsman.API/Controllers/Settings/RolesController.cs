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
    [AuthorizeByPermissions(PermissionTypes = new[] { Permissions.Role })]
    /// <summary>
    ///     Controller for <see cref="Role"/> entity
    /// </summary>
    public partial class RolesController: ClientApiController<RoleModel, Role, int, IRoleManager>
    {

        public RolesController(IRoleManager manager): base(manager){}

        protected override void EntityToModel(Role entity, RoleModel model)
        {
            model.name = entity.Name;
            model.createDate = ((ISystemFields)entity).CreateDate;
            model.changeDate = ((ISystemFields)entity).ChangeDate;
        }
        protected override void ModelToEntity(RoleModel model, Role entity, ActionTypes actionType)
        {
            entity.Name = model.name;
        }
    }
}
