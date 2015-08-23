using CoreBase.Managers;
using ProfiCraftsman.Contracts;
using ProfiCraftsman.Contracts.Entities;
using ProfiCraftsman.Contracts.Managers;
using System;

namespace ProfiCraftsman.Lib.Managers
{
    public partial class PositionsManager: EntityManager<Positions, int>
        ,IPositionsManager
    {

        public PositionsManager(IProfiCraftsmanEntities context): base(context){}

    }
}
