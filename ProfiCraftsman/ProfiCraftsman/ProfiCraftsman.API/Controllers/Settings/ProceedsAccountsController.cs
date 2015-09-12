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
    [AuthorizeByPermissions(PermissionTypes = new[] { Permissions.ProceedsAccounts })]
    /// <summary>
    ///     Controller for <see cref="ProceedsAccounts"/> entity
    /// </summary>
    public partial class ProceedsAccountsController: ClientApiController<ProceedsAccountsModel, ProceedsAccounts, int, IProceedsAccountsManager>
    {

        public ProceedsAccountsController(IProceedsAccountsManager manager): base(manager){}

        protected override void EntityToModel(ProceedsAccounts entity, ProceedsAccountsModel model)
        {
            model.value = entity.Value;
            model.createDate = ((ISystemFields)entity).CreateDate;
            model.changeDate = ((ISystemFields)entity).ChangeDate;
        }
        protected override void ModelToEntity(ProceedsAccountsModel model, ProceedsAccounts entity, ActionTypes actionType)
        {
            entity.Value = model.value;
        }
    }
}
