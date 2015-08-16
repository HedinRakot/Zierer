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
    [AuthorizeByPermissions(PermissionTypes = new[] { Permissions.ProductTypes })]
    /// <summary>
    ///     Controller for <see cref="ProductTypes"/> entity
    /// </summary>
    public partial class ProductTypesController: ClientApiController<ProductTypesModel, ProductTypes, int, IProductTypesManager>
    {

        public ProductTypesController(IProductTypesManager manager): base(manager){}

        protected override void EntityToModel(ProductTypes entity, ProductTypesModel model)
        {
            model.name = entity.Name;
            model.comment = entity.Comment;
            model.createDate = ((ISystemFields)entity).CreateDate;
            model.changeDate = ((ISystemFields)entity).ChangeDate;
        }
        protected override void ModelToEntity(ProductTypesModel model, ProductTypes entity, ActionTypes actionType)
        {
            entity.Name = model.name;
            entity.Comment = model.comment;
        }
    }
}
