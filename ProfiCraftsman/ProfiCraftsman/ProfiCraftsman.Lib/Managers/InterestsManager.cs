using CoreBase.Managers;
using ProfiCraftsman.Contracts;
using ProfiCraftsman.Contracts.Entities;
using ProfiCraftsman.Contracts.Managers;
using System;

namespace ProfiCraftsman.Lib.Managers
{
    public partial class InterestsManager: EntityManager<Interests, int>
        ,IInterestsManager
    {

        public InterestsManager(IProfiCraftsmanEntities context): base(context){}

    }
}
