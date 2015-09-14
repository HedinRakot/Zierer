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
    [AuthorizeByPermissions(PermissionTypes = new[] { Permissions.ForeignProducts })]
    /// <summary>
    ///     Controller for <see cref="ForeignProducts"/> entity
    /// </summary>
    public partial class ForeignProductsController: ClientApiController<ForeignProductsModel, ForeignProducts, int, IForeignProductsManager>
    {

        public ForeignProductsController(IForeignProductsManager manager): base(manager){}

        protected override void EntityToModel(ForeignProducts entity, ForeignProductsModel model)
        {
            model.description = entity.Description;
            model.price = entity.Price;
            model.fromDate = entity.FromDate;
            model.toDate = entity.ToDate;
            model.proceedsAccountId = entity.ProceedsAccountId;
            model.createDate = ((ISystemFields)entity).CreateDate;
            model.changeDate = ((ISystemFields)entity).ChangeDate;
        }
        protected override void ModelToEntity(ForeignProductsModel model, ForeignProducts entity, ActionTypes actionType)
        {
            entity.Description = model.description;
            entity.Price = model.price;
            entity.FromDate = model.fromDate;
            entity.ToDate = model.toDate;
            entity.ProceedsAccountId = model.proceedsAccountId;
        }
    }
}
