using CoreBase.Managers;
using ProfiCraftsman.Contracts;
using ProfiCraftsman.Contracts.Entities;
using ProfiCraftsman.Contracts.Managers;
using System;

namespace ProfiCraftsman.Lib.Managers
{
    public partial class CustomProductsManager: EntityManager<CustomProducts, int>
        ,ICustomProductsManager
    {

        public CustomProductsManager(IProfiCraftsmanEntities context): base(context){}

    }
}
