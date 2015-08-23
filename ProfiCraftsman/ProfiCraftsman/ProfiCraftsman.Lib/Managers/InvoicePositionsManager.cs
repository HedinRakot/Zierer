using CoreBase.Managers;
using ProfiCraftsman.Contracts;
using ProfiCraftsman.Contracts.Entities;
using ProfiCraftsman.Contracts.Managers;
using System;

namespace ProfiCraftsman.Lib.Managers
{
    public partial class InvoicePositionsManager: EntityManager<InvoicePositions, int>
        ,IInvoicePositionsManager
    {

        public InvoicePositionsManager(IProfiCraftsmanEntities context): base(context){}

    }
}
