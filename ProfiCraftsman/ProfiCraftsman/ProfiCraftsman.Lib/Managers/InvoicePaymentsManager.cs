using CoreBase.Managers;
using ProfiCraftsman.Contracts;
using ProfiCraftsman.Contracts.Entities;
using ProfiCraftsman.Contracts.Managers;
using System;

namespace ProfiCraftsman.Lib.Managers
{
    public partial class InvoicePaymentsManager: EntityManager<InvoicePayments, int>
        ,IInvoicePaymentsManager
    {

        public InvoicePaymentsManager(IProfiCraftsmanEntities context): base(context){}

    }
}
