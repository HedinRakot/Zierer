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
    [AuthorizeByPermissions(PermissionTypes = new[] { Permissions.Autos })]
    /// <summary>
    ///     Controller for <see cref="Autos"/> entity
    /// </summary>
    public partial class AutosController: ClientApiController<AutosModel, Autos, int, IAutosManager>
    {

        public AutosController(IAutosManager manager): base(manager){}

        protected override void EntityToModel(Autos entity, AutosModel model)
        {
            model.number = entity.Number;
            model.comment = entity.Comment;
            model.lastInspectionDate = entity.LastInspectionDate;
            model.createDate = ((ISystemFields)entity).CreateDate;
            model.changeDate = ((ISystemFields)entity).ChangeDate;
        }
        protected override void ModelToEntity(AutosModel model, Autos entity, ActionTypes actionType)
        {
            entity.Number = model.number;
            entity.Comment = model.comment;
            entity.LastInspectionDate = model.lastInspectionDate;
        }
    }
}
