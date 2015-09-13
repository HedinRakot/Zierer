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
    [AuthorizeByPermissions(PermissionTypes = new[] { Permissions.AdditionalCosts })]
    /// <summary>
    ///     Controller for <see cref="AdditionalCosts"/> entity
    /// </summary>
    public partial class AdditionalCostsController: ClientApiController<AdditionalCostsModel, AdditionalCosts, int, IAdditionalCostsManager>
    {

        public AdditionalCostsController(IAdditionalCostsManager manager): base(manager){}

        protected override void EntityToModel(AdditionalCosts entity, AdditionalCostsModel model)
        {
            model.price = entity.Price;
            model.automatic = entity.Automatic;
            model.fromDate = entity.FromDate;
            model.toDate = entity.ToDate;
            model.additionalCostTypeId = entity.AdditionalCostTypeId;
            model.proceedsAccountId = entity.ProceedsAccountId;
            model.description = entity.Description;
            model.createDate = ((ISystemFields)entity).CreateDate;
            model.changeDate = ((ISystemFields)entity).ChangeDate;
        }
        protected override void ModelToEntity(AdditionalCostsModel model, AdditionalCosts entity, ActionTypes actionType)
        {
            entity.Price = model.price;
            entity.Automatic = model.automatic;
            entity.FromDate = model.fromDate;
            entity.ToDate = model.toDate;
            entity.AdditionalCostTypeId = model.additionalCostTypeId;
            entity.ProceedsAccountId = model.proceedsAccountId;
            entity.Description = model.description;
        }
    }
}
