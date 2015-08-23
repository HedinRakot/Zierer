using CoreBase.Managers;
using ProfiCraftsman.Contracts;
using ProfiCraftsman.Contracts.Entities;
using ProfiCraftsman.Contracts.Managers;
using System;

namespace ProfiCraftsman.Lib.Managers
{
    public partial class TransportOrdersManager: EntityManager<TransportOrders, int>
        ,ITransportOrdersManager
    {

        public TransportOrdersManager(IProfiCraftsmanEntities context): base(context){}

    }
}
