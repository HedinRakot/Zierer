using CoreBase.Managers;
using ProfiCraftsman.Contracts;
using ProfiCraftsman.Contracts.Entities;
using ProfiCraftsman.Contracts.Managers;
using System;

namespace ProfiCraftsman.Lib.Managers
{
    public partial class TermCostsManager: EntityManager<TermCosts, int>
        ,ITermCostsManager
    {

        public TermCostsManager(IProfiCraftsmanEntities context): base(context){}

    }
}
