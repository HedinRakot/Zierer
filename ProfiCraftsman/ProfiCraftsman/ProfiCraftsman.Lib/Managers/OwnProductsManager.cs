using CoreBase.Managers;
using ProfiCraftsman.Contracts;
using ProfiCraftsman.Contracts.Entities;
using ProfiCraftsman.Contracts.Managers;
using System;

namespace ProfiCraftsman.Lib.Managers
{
    public partial class OwnProductsManager: EntityManager<OwnProducts, int>
        ,IOwnProductsManager
    {

        public OwnProductsManager(IProfiCraftsmanEntities context): base(context){}

    }
}
