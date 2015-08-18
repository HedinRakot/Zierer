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
    /// <summary>
    ///     Controller for <see cref="ProductMaterialRsp"/> entity
    /// </summary>
    public partial class ProductMaterialRspsController: ClientApiController<ProductMaterialRspModel, ProductMaterialRsp, int, IProductMaterialRspManager>
    {

        public ProductMaterialRspsController(IProductMaterialRspManager manager): base(manager){}

        protected override void EntityToModel(ProductMaterialRsp entity, ProductMaterialRspModel model)
        {
            model.productId = entity.ProductId;
            model.materialId = entity.MaterialId;
            model.amount = entity.Amount;
            model.createDate = ((ISystemFields)entity).CreateDate;
            model.changeDate = ((ISystemFields)entity).ChangeDate;
        }
        protected override void ModelToEntity(ProductMaterialRspModel model, ProductMaterialRsp entity, ActionTypes actionType)
        {
            entity.ProductId = model.productId;
            entity.MaterialId = model.materialId;
            entity.Amount = model.amount;
        }
    }
}
