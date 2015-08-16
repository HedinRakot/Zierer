using ProfiCraftsman.API.Models;
using ProfiCraftsman.API.Models.Invoices;
using ProfiCraftsman.API.Security;
using ProfiCraftsman.Contracts.Enums;
using ProfiCraftsman.Contracts.Managers;
using ProfiCraftsman.Contracts.Services;
using CoreBase;
using System;
using System.Web.Http;

namespace ProfiCraftsman.API.Controllers
{

    /// <summary>
    ///     Controller for close Transport order
    /// </summary>
    [AuthorizeByPermissions(PermissionTypes = new[] { Permissions.TransportOrders })]
    public partial class CloseTransportOrderController : ApiController
    {
        private readonly ITransportOrdersManager manager;

        public CloseTransportOrderController(ITransportOrdersManager manager)
        {
            this.manager = manager;
        }

        public IHttpActionResult Put(TransportOrdersModel model)
        {
            var transportOrder = manager.GetById(model.Id);
            transportOrder.Status = (int)OrderStatusTypes.Closed;
            manager.SaveChanges();

            return Ok(new { id = model.Id });
        }
    }
}
