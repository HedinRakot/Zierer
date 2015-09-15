using CoreBase.Managers;
using ProfiCraftsman.Contracts;
using ProfiCraftsman.Contracts.Entities;
using ProfiCraftsman.Contracts.Managers;
using System;

namespace ProfiCraftsman.Lib.Managers
{
    public partial class SocialTaxesManager: EntityManager<SocialTaxes, int>
        ,ISocialTaxesManager
    {

        public SocialTaxesManager(IProfiCraftsmanEntities context): base(context){}

    }
}
