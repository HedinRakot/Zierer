using CoreBase.Managers;
using ProfiCraftsman.Contracts;
using ProfiCraftsman.Contracts.Entities;
using ProfiCraftsman.Contracts.Managers;
using System;

namespace ProfiCraftsman.Lib.Managers
{
    public partial class ProductMaterialRspManager: EntityManager<ProductMaterialRsp, int>
        ,IProductMaterialRspManager
    {

        public ProductMaterialRspManager(IProfiCraftsmanEntities context): base(context){}

    }
}
