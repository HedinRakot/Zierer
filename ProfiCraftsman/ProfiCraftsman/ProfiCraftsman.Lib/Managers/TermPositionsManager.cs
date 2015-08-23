using CoreBase.Managers;
using ProfiCraftsman.Contracts;
using ProfiCraftsman.Contracts.Entities;
using ProfiCraftsman.Contracts.Managers;
using System;

namespace ProfiCraftsman.Lib.Managers
{
    public partial class TermPositionsManager: EntityManager<TermPositions, int>
        ,ITermPositionsManager
    {

        public TermPositionsManager(IProfiCraftsmanEntities context): base(context){}

    }
}
