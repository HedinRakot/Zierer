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
    [AuthorizeByPermissions(PermissionTypes = new[] { Permissions.JobPositions })]
    /// <summary>
    ///     Controller for <see cref="JobPositions"/> entity
    /// </summary>
    public partial class JobPositionsController: ClientApiController<JobPositionsModel, JobPositions, int, IJobPositionsManager>
    {

        public JobPositionsController(IJobPositionsManager manager): base(manager){}

        protected override void EntityToModel(JobPositions entity, JobPositionsModel model)
        {
            model.name = entity.Name;
            model.comment = entity.Comment;
            model.createDate = ((ISystemFields)entity).CreateDate;
            model.changeDate = ((ISystemFields)entity).ChangeDate;
        }
        protected override void ModelToEntity(JobPositionsModel model, JobPositions entity, ActionTypes actionType)
        {
            entity.Name = model.name;
            entity.Comment = model.comment;
        }
    }
}
