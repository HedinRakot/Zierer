using System.Collections.Generic;
using ProfiCraftsman.Contracts.SaveActors;
using CoreBase.SaveActors;

namespace ProfiCraftsman.Lib.Data.SaveActors
{
    public sealed class ProfiCraftsmanSaveActorManager : SaveActorManager<IProfiCraftsmanSaveActor>, IProfiCraftsmanSaveActorManager
    {
        public ProfiCraftsmanSaveActorManager(IProfiCraftsmanSaveActor[] actors)
            : base(actors)
        {
        }
    }
}
