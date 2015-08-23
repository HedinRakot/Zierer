using CoreBase.Managers;
using ProfiCraftsman.Contracts;
using ProfiCraftsman.Contracts.Entities;
using ProfiCraftsman.Contracts.Managers;
using System;

namespace ProfiCraftsman.Lib.Managers
{
    public partial class AutoInstrumentRspManager: EntityManager<AutoInstrumentRsp, int>
        ,IAutoInstrumentRspManager
    {

        public AutoInstrumentRspManager(IProfiCraftsmanEntities context): base(context){}

    }
}
