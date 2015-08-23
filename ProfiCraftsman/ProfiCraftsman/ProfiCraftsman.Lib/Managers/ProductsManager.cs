using CoreBase.Managers;
using ProfiCraftsman.Contracts;
using ProfiCraftsman.Contracts.Entities;
using ProfiCraftsman.Contracts.Managers;
using System;

namespace ProfiCraftsman.Lib.Managers
{
    public partial class ProductsManager: EntityManager<Products, int>
        ,IProductsManager
    {

        public ProductsManager(IProfiCraftsmanEntities context): base(context){}

    }
}
