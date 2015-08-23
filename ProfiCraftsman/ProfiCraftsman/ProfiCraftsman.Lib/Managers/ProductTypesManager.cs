using CoreBase.Managers;
using ProfiCraftsman.Contracts;
using ProfiCraftsman.Contracts.Entities;
using ProfiCraftsman.Contracts.Managers;
using System;

namespace ProfiCraftsman.Lib.Managers
{
    public partial class ProductTypesManager: EntityManager<ProductTypes, int>
        ,IProductTypesManager
    {

        public ProductTypesManager(IProfiCraftsmanEntities context): base(context){}

    }
}
