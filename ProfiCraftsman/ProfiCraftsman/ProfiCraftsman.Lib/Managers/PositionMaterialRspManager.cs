using CoreBase.Managers;
using ProfiCraftsman.Contracts;
using ProfiCraftsman.Contracts.Entities;
using ProfiCraftsman.Contracts.Managers;
using System;

namespace ProfiCraftsman.Lib.Managers
{
    public partial class PositionMaterialRspManager: EntityManager<PositionMaterialRsp, int>
        ,IPositionMaterialRspManager
    {

        public PositionMaterialRspManager(IProfiCraftsmanEntities context): base(context){}

    }
}
