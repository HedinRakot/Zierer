using ProfiCraftsman.API.Models;
using ProfiCraftsman.API.Models.Invoices;
using ProfiCraftsman.API.Security;
using ProfiCraftsman.Contracts.Entities;
using ProfiCraftsman.Contracts.Enums;
using ProfiCraftsman.Contracts.Managers;
using ProfiCraftsman.Contracts.Services;
using CoreBase;
using System;
using System.Web.Http;
using System.Linq;
using System.Collections.Generic;

namespace ProfiCraftsman.API.Controllers
{

    /// <summary>
    ///     Controller for copy order
    /// </summary>
    [AuthorizeByPermissions(PermissionTypes = new[] { Permissions.Orders })]
    public partial class CopyOrderController : ApiController
    {
        private readonly IOrdersManager manager;
        private readonly IPositionsManager positionManager;
        private readonly IUniqueNumberProvider numberProvider;

        public CopyOrderController(IOrdersManager manager, IPositionsManager positionManager, IUniqueNumberProvider numberProvider)
        {
            this.manager = manager;
            this.positionManager = positionManager;
            this.numberProvider = numberProvider;
        }

        public IHttpActionResult Put(OrdersModel model)
        {
            var order = manager.GetById(model.Id);

            var newOrder = new Orders()
            {
                AutoBill = order.AutoBill,
                BillTillDate = order.BillTillDate,
                AutoProlongation = order.AutoProlongation,
                City = order.City,
                Comment = order.Comment,
                CommunicationPartnerId = order.CommunicationPartnerId,
                CustomerId = order.CustomerId,
                DeliveryPlace = order.DeliveryPlace,
                Discount = order.Discount,
                Street = order.Street,
                Status = (int)OrderStatusTypes.Open,
                OrderedFrom = order.OrderedFrom,
                Zip = order.Zip,
                OrderDate = order.OrderDate,
                CustomerOrderNumber = order.CustomerOrderNumber,
                IsOffer = false,
                OrderNumber = numberProvider.GetNextOrderNumber(),
                RentOrderNumber = numberProvider.GetNextRentOrderNumber(Contracts.Configuration.RentOrderPreffix),
                Positions = new List<Positions>(),
                CreateDate = DateTime.Now,
                ChangeDate = DateTime.Now,
            };
            
            manager.AddEntity(newOrder);

            foreach(var position in order.Positions.Where(o => o.AdditionalCostId.HasValue && !o.DeleteDate.HasValue).ToList())
            {
                var newPosition = new Positions()
                {
                    AdditionalCostId = position.AdditionalCostId.Value,
                    IsMain = position.IsMain,
                    IsSellOrder = position.IsSellOrder,
                    FromDate = DateTime.Now,
                    ToDate = DateTime.Now,
                    Amount = position.Amount,
                    Price = position.Price,
                    PaymentType = position.PaymentType,
                    Orders = newOrder
                };

                positionManager.AddEntity(newPosition);
                newOrder.Positions.Add(newPosition);
            }

            manager.SaveChanges();

            return Ok(new { id = newOrder.Id });
        }
    }
}
