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
    ///     Controller for <see cref="ProductEquipmentRsp"/> entity
    /// </summary>
    public partial class ProductEquipmentRspsController: ClientApiController<ProductEquipmentRspModel, ProductEquipmentRsp, int, IProductEquipmentRspManager>
    {

        public ProductEquipmentRspsController(IProductEquipmentRspManager manager): base(manager){}

        protected override void EntityToModel(ProductEquipmentRsp entity, ProductEquipmentRspModel model)
        {
            model.productId = entity.ProductId;
            model.equipmentId = entity.EquipmentId;
            model.amount = entity.Amount;
            model.createDate = ((ISystemFields)entity).CreateDate;
            model.changeDate = ((ISystemFields)entity).ChangeDate;
        }
        protected override void ModelToEntity(ProductEquipmentRspModel model, ProductEquipmentRsp entity, ActionTypes actionType)
        {
            entity.ProductId = model.productId;
            entity.EquipmentId = model.equipmentId;
            entity.Amount = model.amount;
        }
    }
}
