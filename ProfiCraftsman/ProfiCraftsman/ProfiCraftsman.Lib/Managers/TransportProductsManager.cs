using CoreBase.Managers;
using ProfiCraftsman.Contracts;
using ProfiCraftsman.Contracts.Entities;
using ProfiCraftsman.Contracts.Managers;
using System;

namespace ProfiCraftsman.Lib.Managers
{
    public partial class TransportProductsManager: EntityManager<TransportProducts, int>
        ,ITransportProductsManager
    {

        public TransportProductsManager(IProfiCraftsmanEntities context): base(context){}

    }
}
