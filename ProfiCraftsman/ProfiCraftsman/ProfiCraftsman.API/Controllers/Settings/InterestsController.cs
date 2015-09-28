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
    [AuthorizeByPermissions(PermissionTypes = new[] { Permissions.Interests })]
    /// <summary>
    ///     Controller for <see cref="Interests"/> entity
    /// </summary>
    public partial class InterestsController: ClientApiController<InterestsModel, Interests, int, IInterestsManager>
    {

        public InterestsController(IInterestsManager manager): base(manager){}

        protected override void EntityToModel(Interests entity, InterestsModel model)
        {
            model.description = entity.Description;
            model.price = entity.Price;
            model.proceedsAccountId = entity.ProceedsAccountId;
            model.fromDate = entity.FromDate;
            model.toDate = entity.ToDate;
            model.createDate = ((ISystemFields)entity).CreateDate;
            model.changeDate = ((ISystemFields)entity).ChangeDate;
        }
        protected override void ModelToEntity(InterestsModel model, Interests entity, ActionTypes actionType)
        {
            entity.Description = model.description;
            entity.Price = model.price;
            entity.ProceedsAccountId = model.proceedsAccountId;
            entity.FromDate = model.fromDate;
            entity.ToDate = model.toDate;
        }
    }
}
