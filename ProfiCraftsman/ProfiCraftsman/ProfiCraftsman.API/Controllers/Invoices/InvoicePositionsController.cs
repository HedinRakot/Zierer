using CoreBase.Controllers;
using CoreBase.Entities;
using ProfiCraftsman.API.Models;
using ProfiCraftsman.API.Models.Invoices;
using ProfiCraftsman.API.Security;
using ProfiCraftsman.Contracts;
using ProfiCraftsman.Contracts.Entities;
using ProfiCraftsman.Contracts.Enums;
using ProfiCraftsman.Contracts.Managers;
using ProfiCraftsman.Lib.Managers;
using System;

namespace ProfiCraftsman.API.Controllers.Invoices
{
    /// <summary>
    ///     Controller for <see cref="InvoicePositions"/> entity
    /// </summary>
    [AuthorizeByPermissions(PermissionTypes = new[] { Permissions.Invoices })]
    public partial class InvoicePositionsController: ClientApiController<InvoicePositionsModel, InvoicePositions, int, IInvoicePositionsManager>
    {

        public InvoicePositionsController(IInvoicePositionsManager manager): base(manager){}

        protected override void EntityToModel(InvoicePositions entity, InvoicePositionsModel model)
        {
            model.price = entity.Price;
            model.createDate = ((ISystemFields)entity).CreateDate;
            model.changeDate = ((ISystemFields)entity).ChangeDate;
            model.amount = entity.Amount;
            model.paymentType = entity.PaymentType;

            if (entity.Positions.ProductId.HasValue)
            {
                model.description = String.Format("{0} {1}", entity.Positions.Products.Number, entity.Positions.Products.ProductTypes.Name);
                model.isCointainerPosition = true;
                model.price = entity.Price;

                model.totalPrice = CalculationHelper.CalculatePositionPrice(entity.Price, entity.Amount, entity.Payment);
            }

            if (entity.Positions.MaterialId.HasValue)
            {
                model.totalPrice = model.price * model.amount;
                model.description = entity.Positions.Materials.Name;
                model.isCointainerPosition = false;
            }
        }
        protected override void ModelToEntity(InvoicePositionsModel model, InvoicePositions entity, ActionTypes actionType)
        {
            entity.Price = model.price;
            entity.PaymentType = model.paymentType;
        }
    }
}
