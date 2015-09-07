using CoreBase.Managers;
using ProfiCraftsman.Contracts;
using ProfiCraftsman.Contracts.Entities;
using ProfiCraftsman.Contracts.Managers;
using System;

namespace ProfiCraftsman.Lib.Managers
{
    public partial class TermPositionMaterialRspManager: EntityManager<TermPositionMaterialRsp, int>
        ,ITermPositionMaterialRspManager
    {

        public TermPositionMaterialRspManager(IProfiCraftsmanEntities context): base(context){}

    }
}
