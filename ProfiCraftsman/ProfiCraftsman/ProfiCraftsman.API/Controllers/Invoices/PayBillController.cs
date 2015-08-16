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
    ///     Controller for pay bill
    /// </summary>
    [AuthorizeByPermissions(PermissionTypes = new[] { Permissions.Invoices })]
    public partial class PayBillController : ApiController
    {
        private readonly IInvoicesManager manager;

        public PayBillController(IInvoicesManager manager)
        {
            this.manager = manager;
        }

        public IHttpActionResult Put(InvoicesModel model)
        {
            var invoice = manager.GetById(model.Id);
            invoice.PayDate = DateTime.Now;
            manager.SaveChanges();

            return Ok(new { id = model.Id });
        }
    }
}
