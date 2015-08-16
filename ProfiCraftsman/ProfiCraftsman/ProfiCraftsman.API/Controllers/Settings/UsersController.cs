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
    [AuthorizeByPermissions(PermissionTypes = new[] { Permissions.User })]
    /// <summary>
    ///     Controller for <see cref="User"/> entity
    /// </summary>
    public partial class UsersController: ClientApiController<UserModel, User, int, IUserManager>
    {

        public UsersController(IUserManager manager): base(manager){}

        protected override void EntityToModel(User entity, UserModel model)
        {
            model.roleId = entity.RoleId;
            model.login = entity.Login;
            model.name = entity.Name;
            model.password = entity.Password;
            model.createDate = ((ISystemFields)entity).CreateDate;
            model.changeDate = ((ISystemFields)entity).ChangeDate;
        }
        protected override void ModelToEntity(UserModel model, User entity, ActionTypes actionType)
        {
            entity.RoleId = model.roleId;
            entity.Login = model.login;
            entity.Name = model.name;
            entity.Password = model.password;
        }
    }
}
