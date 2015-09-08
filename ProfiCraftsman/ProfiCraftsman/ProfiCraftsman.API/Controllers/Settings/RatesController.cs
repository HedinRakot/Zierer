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
    [AuthorizeByPermissions(PermissionTypes = new[] { Permissions.Rates })]
    /// <summary>
    ///     Controller for <see cref="Rates"/> entity
    /// </summary>
    public partial class RatesController: ClientApiController<RatesModel, Rates, int, IRatesManager>
    {

        public RatesController(IRatesManager manager): base(manager){}

        protected override void EntityToModel(Rates entity, RatesModel model)
        {
            model.jobPositionId = entity.JobPositionId;
            model.price = entity.Price;
            model.fromDate = entity.FromDate;
            model.toDate = entity.ToDate;
            model.createDate = ((ISystemFields)entity).CreateDate;
            model.changeDate = ((ISystemFields)entity).ChangeDate;
        }
        protected override void ModelToEntity(RatesModel model, Rates entity, ActionTypes actionType)
        {
            entity.JobPositionId = model.jobPositionId;
            entity.Price = model.price;
            entity.FromDate = model.fromDate;
            entity.ToDate = model.toDate;
        }
    }
}
