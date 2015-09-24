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
    [AuthorizeByPermissions(PermissionTypes = new[] { Permissions.Absences })]
    /// <summary>
    ///     Controller for <see cref="Absences"/> entity
    /// </summary>
    public partial class AbsencesController: ClientApiController<AbsencesModel, Absences, int, IAbsencesManager>
    {

        public AbsencesController(IAbsencesManager manager): base(manager){}

        protected override void EntityToModel(Absences entity, AbsencesModel model)
        {
            model.employeeId = entity.EmployeeId;
            model.description = entity.Description;
            model.fromDate = entity.FromDate;
            model.toDate = entity.ToDate;
            model.createDate = ((ISystemFields)entity).CreateDate;
            model.changeDate = ((ISystemFields)entity).ChangeDate;
        }
        protected override void ModelToEntity(AbsencesModel model, Absences entity, ActionTypes actionType)
        {
            entity.EmployeeId = model.employeeId;
            entity.Description = model.description;
            entity.FromDate = model.fromDate;
            entity.ToDate = model.toDate;
        }
    }
}
