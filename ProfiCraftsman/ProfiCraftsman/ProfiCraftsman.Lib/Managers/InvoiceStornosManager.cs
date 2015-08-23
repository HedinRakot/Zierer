using CoreBase.Managers;
using ProfiCraftsman.Contracts;
using ProfiCraftsman.Contracts.Entities;
using ProfiCraftsman.Contracts.Managers;
using System;

namespace ProfiCraftsman.Lib.Managers
{
    public partial class InvoiceStornosManager: EntityManager<InvoiceStornos, int>
        ,IInvoiceStornosManager
    {

        public InvoiceStornosManager(IProfiCraftsmanEntities context): base(context){}

    }
}
