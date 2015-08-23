using CoreBase.Managers;
using ProfiCraftsman.Contracts;
using ProfiCraftsman.Contracts.Entities;
using ProfiCraftsman.Contracts.Managers;
using System;

namespace ProfiCraftsman.Lib.Managers
{
    public partial class InvoicesManager: EntityManager<Invoices, int>
        ,IInvoicesManager
    {

        public InvoicesManager(IProfiCraftsmanEntities context): base(context){}

    }
}
