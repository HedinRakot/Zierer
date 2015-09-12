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
    ///     Controller for <see cref="InvoicePayments"/> entity
    /// </summary>
    [AuthorizeByPermissions(PermissionTypes = new[] { Permissions.Invoices })]
    public partial class InvoicePaymentsController : ClientApiController<InvoicePaymentsModel, InvoicePayments, int, IInvoicePaymentsManager>
    {

        public InvoicePaymentsController(IInvoicePaymentsManager manager): base(manager){}

        protected override void EntityToModel(InvoicePayments entity, InvoicePaymentsModel model)
        {
            model.createDate = ((ISystemFields)entity).CreateDate;
            model.changeDate = ((ISystemFields)entity).ChangeDate;
            model.invoiceId = entity.InvoiceId;
            model.amount = entity.Amount;
        }
        protected override void ModelToEntity(InvoicePaymentsModel model, InvoicePayments entity, ActionTypes actionType)
        {
            entity.InvoiceId = model.invoiceId;
            entity.Amount = model.amount;
        }
    }
}
