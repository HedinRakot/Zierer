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
    [AuthorizeByPermissions(PermissionTypes = new[] { Permissions.Products })]
    /// <summary>
    ///     Controller for <see cref="Products"/> entity
    /// </summary>
    public partial class ProductsController: ClientApiController<ProductsModel, Products, int, IProductsManager>
    {

        public ProductsController(IProductsManager manager): base(manager){}

        protected override void EntityToModel(Products entity, ProductsModel model)
        {
            model.number = entity.Number;
            model.productTypeId = entity.ProductTypeId;
            model.price = entity.Price;
            model.proceedsAccount = entity.ProceedsAccount;
            model.comment = entity.Comment;
            model.name = entity.Name;
            model.productAmountType = entity.ProductAmountType;
            model.createDate = ((ISystemFields)entity).CreateDate;
            model.changeDate = ((ISystemFields)entity).ChangeDate;
        }
        protected override void ModelToEntity(ProductsModel model, Products entity, ActionTypes actionType)
        {
            entity.Number = model.number;
            entity.ProductTypeId = model.productTypeId;
            entity.Price = model.price;
            entity.ProceedsAccount = model.proceedsAccount;
            entity.Comment = model.comment;
            entity.Name = model.name;
            entity.ProductAmountType = model.productAmountType;
        }
    }
}
