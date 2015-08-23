using CoreBase.Managers;
using ProfiCraftsman.Contracts;
using ProfiCraftsman.Contracts.Entities;
using ProfiCraftsman.Contracts.Managers;
using System;

namespace ProfiCraftsman.Lib.Managers
{
    public partial class AutoMaterialRspManager: EntityManager<AutoMaterialRsp, int>
        ,IAutoMaterialRspManager
    {

        public AutoMaterialRspManager(IProfiCraftsmanEntities context): base(context){}

    }
}
