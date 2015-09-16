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
    ///     Controller for <see cref="RolePermissionRsp"/> entity
    /// </summary>
    public partial class RolePermissionRspsController: ClientApiController<RolePermissionRspModel, RolePermissionRsp, int, IRolePermissionRspManager>
    {

        public RolePermissionRspsController(IRolePermissionRspManager manager): base(manager){}

        protected override void EntityToModel(RolePermissionRsp entity, RolePermissionRspModel model)
        {
            model.roleId = entity.RoleId;
            model.permissionId = entity.PermissionId;
            model.createDate = ((ISystemFields)entity).CreateDate;
            model.changeDate = ((ISystemFields)entity).ChangeDate;
        }
        protected override void ModelToEntity(RolePermissionRspModel model, RolePermissionRsp entity, ActionTypes actionType)
        {
            entity.RoleId = model.roleId;
            entity.PermissionId = model.permissionId;

            ExtraModelToEntity(entity, model, actionType);
        }
    }
}
