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
    [AuthorizeByPermissions(PermissionTypes = new[] { Permissions.CustomProducts })]
    /// <summary>
    ///     Controller for <see cref="CustomProducts"/> entity
    /// </summary>
    public partial class CustomProductsController: ClientApiController<CustomProductsModel, CustomProducts, int, ICustomProductsManager>
    {

        public CustomProductsController(ICustomProductsManager manager): base(manager){}

        protected override void EntityToModel(CustomProducts entity, CustomProductsModel model)
        {
            model.name = entity.Name;
            model.price = entity.Price;
            model.auto = entity.Auto;
            model.proceedsAccountId = entity.ProceedsAccountId;
            model.createDate = ((ISystemFields)entity).CreateDate;
            model.changeDate = ((ISystemFields)entity).ChangeDate;
        }
        protected override void ModelToEntity(CustomProductsModel model, CustomProducts entity, ActionTypes actionType)
        {
            entity.Name = model.name;
            entity.Price = model.price;
            entity.Auto = model.auto;
            entity.ProceedsAccountId = model.proceedsAccountId;
        }
    }
}
