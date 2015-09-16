using ProfiCraftsman.API.Models.Settings;
using ProfiCraftsman.Contracts.Entities;
using System.Web.Http;
using CoreBase;
using CoreBase.Models;
using CoreBase.Controllers;
using System;

namespace ProfiCraftsman.API.Controllers.Settings
{
    public partial class RolePermissionRspsController
    {
        protected void ExtraModelToEntity(RolePermissionRsp entity, RolePermissionRspModel model, ActionTypes actionType)
        {
            entity.Key = StringHelper.GetMD5Hash(String.Format("{0}_{1}", model.roleId, model.permissionId));
        }
    }
}
