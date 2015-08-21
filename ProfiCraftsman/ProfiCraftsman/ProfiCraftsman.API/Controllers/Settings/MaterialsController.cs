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
    [AuthorizeByPermissions(PermissionTypes = new[] { Permissions.Materials })]
    /// <summary>
    ///     Controller for <see cref="Materials"/> entity
    /// </summary>
    public partial class MaterialsController: ClientApiController<MaterialsModel, Materials, int, IMaterialsManager>
    {

        public MaterialsController(IMaterialsManager manager): base(manager){}

        protected override void EntityToModel(Materials entity, MaterialsModel model)
        {
            model.name = entity.Name;
            model.number = entity.Number;
            model.length = entity.Length;
            model.width = entity.Width;
            model.height = entity.Height;
            model.color = entity.Color;
            model.price = entity.Price;
            model.proceedsAccount = entity.ProceedsAccount;
            model.isVirtual = entity.IsVirtual;
            model.boughtFrom = entity.BoughtFrom;
            model.boughtPrice = entity.BoughtPrice;
            model.comment = entity.Comment;
            model.materialAmountType = entity.MaterialAmountType;
            model.isForAuto = entity.IsForAuto;
            model.mustCount = entity.MustCount;
            model.createDate = ((ISystemFields)entity).CreateDate;
            model.changeDate = ((ISystemFields)entity).ChangeDate;
        }
        protected override void ModelToEntity(MaterialsModel model, Materials entity, ActionTypes actionType)
        {
            entity.Name = model.name;
            entity.Number = model.number;
            entity.Length = model.length;
            entity.Width = model.width;
            entity.Height = model.height;
            entity.Color = model.color;
            entity.Price = model.price;
            entity.ProceedsAccount = model.proceedsAccount;
            entity.IsVirtual = model.isVirtual;
            entity.BoughtFrom = model.boughtFrom;
            entity.BoughtPrice = model.boughtPrice;
            entity.Comment = model.comment;
            entity.MaterialAmountType = model.materialAmountType;
            entity.IsForAuto = model.isForAuto;
            entity.MustCount = model.mustCount;
        }
    }
}
