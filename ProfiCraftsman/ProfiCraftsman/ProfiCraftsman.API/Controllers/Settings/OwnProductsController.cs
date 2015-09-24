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
    [AuthorizeByPermissions(PermissionTypes = new[] { Permissions.OwnProducts })]
    /// <summary>
    ///     Controller for <see cref="OwnProducts"/> entity
    /// </summary>
    public partial class OwnProductsController: ClientApiController<OwnProductsModel, OwnProducts, int, IOwnProductsManager>
    {

        public OwnProductsController(IOwnProductsManager manager): base(manager){}

        protected override void EntityToModel(OwnProducts entity, OwnProductsModel model)
        {
            model.description = entity.Description;
            model.price = entity.Price;
            model.fromDate = entity.FromDate;
            model.toDate = entity.ToDate;
            model.proceedsAccountId = entity.ProceedsAccountId;
            model.createDate = ((ISystemFields)entity).CreateDate;
            model.changeDate = ((ISystemFields)entity).ChangeDate;
        }
        protected override void ModelToEntity(OwnProductsModel model, OwnProducts entity, ActionTypes actionType)
        {
            entity.Description = model.description;
            entity.Price = model.price;
            entity.FromDate = model.fromDate;
            entity.ToDate = model.toDate;
            entity.ProceedsAccountId = model.proceedsAccountId;
        }
    }
}
