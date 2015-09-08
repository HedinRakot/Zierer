using CoreBase.Managers;
using ProfiCraftsman.Contracts;
using ProfiCraftsman.Contracts.Entities;
using ProfiCraftsman.Contracts.Managers;
using System;

namespace ProfiCraftsman.Lib.Managers
{
    public partial class AdditionalCostTypesManager: EntityManager<AdditionalCostTypes, int>
        ,IAdditionalCostTypesManager
    {

        public AdditionalCostTypesManager(IProfiCraftsmanEntities context): base(context){}

    }
}
