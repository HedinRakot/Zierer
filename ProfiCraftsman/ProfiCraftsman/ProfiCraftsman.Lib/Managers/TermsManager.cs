using CoreBase.Managers;
using ProfiCraftsman.Contracts;
using ProfiCraftsman.Contracts.Entities;
using ProfiCraftsman.Contracts.Managers;
using System;

namespace ProfiCraftsman.Lib.Managers
{
    public partial class TermsManager: EntityManager<Terms, int>
        ,ITermsManager
    {

        public TermsManager(IProfiCraftsmanEntities context): base(context){}

    }
}
