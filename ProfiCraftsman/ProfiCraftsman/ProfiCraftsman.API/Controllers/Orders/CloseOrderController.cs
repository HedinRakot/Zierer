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
    ///     Controller for close order
    /// </summary>
    [AuthorizeByPermissions(PermissionTypes = new[] { Permissions.Orders })]
    public partial class CloseOrderController : ApiController
    {
        private readonly IOrdersManager manager;

        public CloseOrderController(IOrdersManager manager)
        {
            this.manager = manager;
        }

        public IHttpActionResult Put(OrdersModel model)
        {
            var order = manager.GetById(model.Id);
            order.Status = (int)OrderStatusTypes.Closed;
            manager.SaveChanges();

            return Ok(new { id = model.Id });
        }
    }
}
