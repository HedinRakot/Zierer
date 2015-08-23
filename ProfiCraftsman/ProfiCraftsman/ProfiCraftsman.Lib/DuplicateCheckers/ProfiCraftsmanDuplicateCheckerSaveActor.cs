using CoreBase.DuplicateCheckers;
using ProfiCraftsman.Contracts.SaveActors;
using ProfiCraftsman.Lib.DuplicateCheckers.Interfaces;

namespace ProfiCraftsman.Lib.DuplicateCheckers
{
    public sealed class ProfiCraftsmanDuplicateCheckerSaveActor : BaseDuplicateCheckerSaveActor<IProfiCraftsmanDuplicateChecker>, IProfiCraftsmanSaveActor
    {
        public ProfiCraftsmanDuplicateCheckerSaveActor(IProfiCraftsmanDuplicateChecker[] checkers)
            : base(checkers)
        {
        }
    }
}
