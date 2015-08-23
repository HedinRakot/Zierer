using CoreBase.Managers;
using ProfiCraftsman.Contracts;
using ProfiCraftsman.Contracts.Entities;
using ProfiCraftsman.Contracts.Managers;
using System;

namespace ProfiCraftsman.Lib.Managers
{
    public partial class InstrumentsManager: EntityManager<Instruments, int>
        ,IInstrumentsManager
    {

        public InstrumentsManager(IProfiCraftsmanEntities context): base(context){}

    }
}
