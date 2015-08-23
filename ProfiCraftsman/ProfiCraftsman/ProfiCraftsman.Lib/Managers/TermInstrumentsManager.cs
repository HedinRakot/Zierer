using CoreBase.Managers;
using ProfiCraftsman.Contracts;
using ProfiCraftsman.Contracts.Entities;
using ProfiCraftsman.Contracts.Managers;
using System;

namespace ProfiCraftsman.Lib.Managers
{
    public partial class TermInstrumentsManager: EntityManager<TermInstruments, int>
        ,ITermInstrumentsManager
    {

        public TermInstrumentsManager(IProfiCraftsmanEntities context): base(context){}

    }
}
