using CoreBase.Managers;
using ProfiCraftsman.Contracts;
using ProfiCraftsman.Contracts.Entities;
using ProfiCraftsman.Contracts.Managers;
using System;

namespace ProfiCraftsman.Lib.Managers
{
    public partial class TransportPositionsManager: EntityManager<TransportPositions, int>
        ,ITransportPositionsManager
    {

        public TransportPositionsManager(IProfiCraftsmanEntities context): base(context){}

    }
}
