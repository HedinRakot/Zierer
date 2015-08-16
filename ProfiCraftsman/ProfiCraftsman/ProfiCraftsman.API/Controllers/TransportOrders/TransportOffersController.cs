using ProfiCraftsman.API.Models;
using ProfiCraftsman.API.Security;
using ProfiCraftsman.Contracts.Enums;
using ProfiCraftsman.Contracts.Managers;
using ProfiCraftsman.Contracts.Services;
using CoreBase;
using System;
using System.Web.Http;
using System.Linq;

namespace ProfiCraftsman.API.Controllers
{

    /// <summary>
    ///     Controller for Transport offers
    /// </summary>
    [AuthorizeByPermissions(PermissionTypes = new[] { Permissions.TransportOrders })]
    public partial class TransportOffersController : ApiController
    {
        private readonly ITransportOrdersManager manager;
        private readonly IUniqueNumberProvider numberProvider;
        private readonly ICustomersManager customerManager;

        public TransportOffersController(ITransportOrdersManager manager, ICustomersManager customerManager, IUniqueNumberProvider numberProvider)
        {
            this.manager = manager;
            this.customerManager = customerManager;
            this.numberProvider = numberProvider;
        }

        public IHttpActionResult Put(TransportOrdersModel model)
        {
            var order = manager.GetById(model.Id);
            order.IsOffer = false;
            
            if (String.IsNullOrEmpty(order.OrderNumber))
            {
                order.OrderNumber = numberProvider.GetNextTransportOrderNumber();
            }

            if (order.Customers.IsProspectiveCustomer)
            {
                order.Customers.IsProspectiveCustomer = false;
                var lastCustomerNumber = customerManager.GetEntities().Max(o => o.Number);
                order.Customers.Number = lastCustomerNumber + 1;
            }
            
            manager.SaveChanges();

            return Ok(new { id = model.Id });
        }
    }
}
