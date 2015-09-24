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
    [AuthorizeByPermissions(PermissionTypes = new[] { Permissions.NotProductiveWorkHours })]
    /// <summary>
    ///     Controller for <see cref="NotProductiveWorkHours"/> entity
    /// </summary>
    public partial class NotProductiveWorkHoursController: ClientApiController<NotProductiveWorkHoursModel, NotProductiveWorkHours, int, INotProductiveWorkHoursManager>
    {

        public NotProductiveWorkHoursController(INotProductiveWorkHoursManager manager): base(manager){}

        protected override void EntityToModel(NotProductiveWorkHours entity, NotProductiveWorkHoursModel model)
        {
            model.employeeId = entity.EmployeeId;
            model.description = entity.Description;
            model.fromDate = entity.FromDate;
            model.toDate = entity.ToDate;
            model.createDate = ((ISystemFields)entity).CreateDate;
            model.changeDate = ((ISystemFields)entity).ChangeDate;
        }
        protected override void ModelToEntity(NotProductiveWorkHoursModel model, NotProductiveWorkHours entity, ActionTypes actionType)
        {
            entity.EmployeeId = model.employeeId;
            entity.Description = model.description;
            entity.FromDate = model.fromDate;
            entity.ToDate = model.toDate;
        }
    }
}
