using CoreBase.Managers;
using ProfiCraftsman.Contracts;
using ProfiCraftsman.Contracts.Entities;
using ProfiCraftsman.Contracts.Managers;
using System;

namespace ProfiCraftsman.Lib.Managers
{
    public partial class RatesManager: EntityManager<Rates, int>
        ,IRatesManager
    {

        public RatesManager(IProfiCraftsmanEntities context): base(context){}

    }
}
