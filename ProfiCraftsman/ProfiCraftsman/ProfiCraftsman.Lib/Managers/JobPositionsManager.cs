using CoreBase.Managers;
using ProfiCraftsman.Contracts;
using ProfiCraftsman.Contracts.Entities;
using ProfiCraftsman.Contracts.Managers;
using System;

namespace ProfiCraftsman.Lib.Managers
{
    public partial class JobPositionsManager: EntityManager<JobPositions, int>
        ,IJobPositionsManager
    {

        public JobPositionsManager(IProfiCraftsmanEntities context): base(context){}

    }
}
