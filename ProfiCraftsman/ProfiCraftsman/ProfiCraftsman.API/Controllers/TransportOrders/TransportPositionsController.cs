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
using System.Linq;
using System.Linq.Dynamic;

namespace ProfiCraftsman.API.Controllers
{
    /// <summary>
    ///     Controller for <see cref="TransportPositions"/> entity
    /// </summary>
    [AuthorizeByPermissions(PermissionTypes = new[] { Permissions.TransportOrders })]
    public partial class TransportPositionsController: ClientApiController<TransportPositionsModel, TransportPositions, int, ITransportPositionsManager>
    {
        public TransportPositionsController(ITransportPositionsManager manager) : base(manager) { }

        protected override void EntityToModel(TransportPositions entity, TransportPositionsModel model)
        {
            model.transportOrderId = entity.TransportOrderId;
            model.transportProductId = entity.TransportProductId;
            model.description = entity.TransportProducts.Name;

            model.amount = entity.Amount;
            model.price = entity.Price;
            model.createDate = ((ISystemFields)entity).CreateDate;
            model.changeDate = ((ISystemFields)entity).ChangeDate;

        }
        protected override void ModelToEntity(TransportPositionsModel model, TransportPositions entity, ActionTypes actionType)
        {
            entity.TransportOrderId = model.transportOrderId;
            entity.TransportProductId = model.transportProductId;
            entity.Price = model.price;
            entity.Amount = model.amount;
        }
    }
}
