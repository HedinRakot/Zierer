using CoreBase.Controllers;
using CoreBase.Entities;
using CoreBase.Exceptions;
using CoreBase.Models;
using ProfiCraftsman.API.Models;
using ProfiCraftsman.API.Models.Settings;
using ProfiCraftsman.API.Security;
using ProfiCraftsman.Contracts;
using ProfiCraftsman.Contracts.Entities;
using ProfiCraftsman.Contracts.Enums;
using ProfiCraftsman.Contracts.Managers;
using ProfiCraftsman.Lib.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Web.Http;

namespace ProfiCraftsman.API.Controllers
{
    /// <summary>
    ///     Controller for <see cref="TermPositions"/> entity
    /// </summary>
    [AuthorizeByPermissions(PermissionTypes = new[] { Permissions.Orders })]
    public partial class TermPositionsController: ClientApiController<TermPositionModel, TermPositions, int, ITermPositionsManager>
    {

        public TermPositionsController(ITermPositionsManager manager) : 
            base(manager)
        {
        }

        protected override void EntityToModel(TermPositions entity, TermPositionModel model)
        {
            model.termId = entity.TermId;
            model.positionId = entity.PositionId;
            model.paymentType = entity.Positions.PaymentType;
            model.amount = entity.Amount;
            model.price = entity.Positions.Price;
            model.description = entity.Positions.Description;
            model.createDate = ((ISystemFields)entity).CreateDate;
            model.changeDate = ((ISystemFields)entity).ChangeDate;

            model.number = entity.Positions.Products.Number;
            model.amountType = entity.Positions.Products.ProductAmountTypeString;

            model.totalPrice = CalculationHelper.CalculatePositionPrice(entity.Positions.Price, entity.Amount, entity.Positions.Payment).ToString("N2") + " EUR";
        }

        protected override void ModelToEntity(TermPositionModel model, TermPositions entity, ActionTypes actionType)
        {
            entity.TermId = model.termId;
            entity.PositionId = model.positionId;
            entity.Amount = model.amount;        
        }      
    }
}
