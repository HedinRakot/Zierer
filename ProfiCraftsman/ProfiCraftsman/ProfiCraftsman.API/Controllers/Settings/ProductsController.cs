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
            model.length = entity.Length;
            model.width = entity.Width;
            model.height = entity.Height;
            model.color = entity.Color;
            model.price = entity.Price;
            model.proceedsAccount = entity.ProceedsAccount;
            model.isVirtual = entity.IsVirtual;
            model.manufactureDate = entity.ManufactureDate;
            model.boughtFrom = entity.BoughtFrom;
            model.boughtPrice = entity.BoughtPrice;
            model.comment = entity.Comment;
            model.sellPrice = entity.SellPrice;
            model.isSold = entity.IsSold;
            model.minPrice = entity.MinPrice;
            model.newPrice = entity.NewPrice;
            model.createDate = ((ISystemFields)entity).CreateDate;
            model.changeDate = ((ISystemFields)entity).ChangeDate;
        }
        protected override void ModelToEntity(ProductsModel model, Products entity, ActionTypes actionType)
        {
            entity.Number = model.number;
            entity.ProductTypeId = model.productTypeId;
            entity.Length = model.length;
            entity.Width = model.width;
            entity.Height = model.height;
            entity.Color = model.color;
            entity.Price = model.price;
            entity.ProceedsAccount = model.proceedsAccount;
            entity.IsVirtual = model.isVirtual;
            entity.ManufactureDate = model.manufactureDate;
            entity.BoughtFrom = model.boughtFrom;
            entity.BoughtPrice = model.boughtPrice;
            entity.Comment = model.comment;
            entity.SellPrice = model.sellPrice;
            entity.IsSold = model.isSold;
            entity.MinPrice = model.minPrice;
            entity.NewPrice = model.newPrice;
        }
    }
}
