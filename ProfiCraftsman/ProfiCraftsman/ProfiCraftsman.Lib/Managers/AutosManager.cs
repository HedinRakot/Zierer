using CoreBase.Managers;
using ProfiCraftsman.Contracts;
using ProfiCraftsman.Contracts.Entities;
using ProfiCraftsman.Contracts.Managers;
using System;

namespace ProfiCraftsman.Lib.Managers
{
    public partial class AutosManager: EntityManager<Autos, int>
        ,IAutosManager
    {

        public AutosManager(IProfiCraftsmanEntities context): base(context){}

    }
}
