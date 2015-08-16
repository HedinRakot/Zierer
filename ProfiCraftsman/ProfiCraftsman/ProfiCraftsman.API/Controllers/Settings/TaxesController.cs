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
    [AuthorizeByPermissions(PermissionTypes = new[] { Permissions.Taxes })]
    /// <summary>
    ///     Controller for <see cref="Taxes"/> entity
    /// </summary>
    public partial class TaxesController: ClientApiController<TaxesModel, Taxes, int, ITaxesManager>
    {

        public TaxesController(ITaxesManager manager): base(manager){}

        protected override void EntityToModel(Taxes entity, TaxesModel model)
        {
            model.value = entity.Value;
            model.fromDate = entity.FromDate;
            model.toDate = entity.ToDate;
            model.createDate = ((ISystemFields)entity).CreateDate;
            model.changeDate = ((ISystemFields)entity).ChangeDate;
        }
        protected override void ModelToEntity(TaxesModel model, Taxes entity, ActionTypes actionType)
        {
            entity.Value = model.value;
            entity.FromDate = model.fromDate;
            entity.ToDate = model.toDate;
        }
    }
}
