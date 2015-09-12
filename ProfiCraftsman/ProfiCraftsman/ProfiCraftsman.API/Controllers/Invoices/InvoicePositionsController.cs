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
            model.createDate = ((ISystemFields)entity).CreateDate;
            model.changeDate = ((ISystemFields)entity).ChangeDate;
            model.invoiceId = entity.InvoiceId;
            model.amount = entity.Amount;
            model.paymentType = entity.PaymentType;
            model.price = entity.Price;
            model.priceString = entity.Price.ToString("N2") + " EUR";

            if (entity.PositionId.HasValue)
            {
                model.description = entity.Positions.Description;

                if (entity.Positions.ProductId.HasValue)
                {
                    model.number = entity.Positions.Products.Number;
                }
                else if (entity.Positions.MaterialId.HasValue)
                {
                    model.number = entity.Positions.Materials.Number;
                }
            }
            else if(entity.TermPositionMaterialId.HasValue)
            {
                model.description = entity.TermPositionMaterialRsp.Materials.Name;
                model.number = entity.TermPositionMaterialRsp.Materials.Number;
            }
            else if(entity.TermCostId.HasValue)
            {
                model.description = entity.TermCosts.Name;
            }

            model.totalPrice = CalculationHelper.CalculatePositionPrice(entity.Price, entity.Amount, entity.Payment).ToString("N2") + " EUR";
        }
        protected override void ModelToEntity(InvoicePositionsModel model, InvoicePositions entity, ActionTypes actionType)
        {
            entity.InvoiceId = model.invoiceId;
            entity.Price = model.price;
            entity.PaymentType = model.paymentType;
        }
    }
}
