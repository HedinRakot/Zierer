using CoreBase.Managers;
using ProfiCraftsman.Contracts;
using ProfiCraftsman.Contracts.Entities;
using ProfiCraftsman.Contracts.Managers;
using System;

namespace ProfiCraftsman.Lib.Managers
{
    public partial class ForeignProductsManager: EntityManager<ForeignProducts, int>
        ,IForeignProductsManager
    {

        public ForeignProductsManager(IProfiCraftsmanEntities context): base(context){}

    }
}
