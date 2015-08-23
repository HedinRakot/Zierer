using CoreBase.Managers;
using ProfiCraftsman.Contracts;
using ProfiCraftsman.Contracts.Entities;
using ProfiCraftsman.Contracts.Managers;
using System;

namespace ProfiCraftsman.Lib.Managers
{
    public partial class AdditionalCostsManager: EntityManager<AdditionalCosts, int>
        ,IAdditionalCostsManager
    {

        public AdditionalCostsManager(IProfiCraftsmanEntities context): base(context){}

    }
}
