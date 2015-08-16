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
    ///     Controller for <see cref="ProductTypeEquipmentRsp"/> entity
    /// </summary>
    public partial class ProductTypeEquipmentRspsController: ClientApiController<ProductTypeEquipmentRspModel, ProductTypeEquipmentRsp, int, IProductTypeEquipmentRspManager>
    {

        public ProductTypeEquipmentRspsController(IProductTypeEquipmentRspManager manager): base(manager){}

        protected override void EntityToModel(ProductTypeEquipmentRsp entity, ProductTypeEquipmentRspModel model)
        {
            model.productTypeId = entity.ProductTypeId;
            model.equipmentId = entity.EquipmentId;
            model.amount = entity.Amount;
            model.createDate = ((ISystemFields)entity).CreateDate;
            model.changeDate = ((ISystemFields)entity).ChangeDate;
        }
        protected override void ModelToEntity(ProductTypeEquipmentRspModel model, ProductTypeEquipmentRsp entity, ActionTypes actionType)
        {
            entity.ProductTypeId = model.productTypeId;
            entity.EquipmentId = model.equipmentId;
            entity.Amount = model.amount;
        }
    }
}
