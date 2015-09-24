using CoreBase.Managers;
using ProfiCraftsman.Contracts;
using ProfiCraftsman.Contracts.Entities;
using ProfiCraftsman.Contracts.Managers;
using System;

namespace ProfiCraftsman.Lib.Managers
{
    public partial class AbsencesManager: EntityManager<Absences, int>
        ,IAbsencesManager
    {

        public AbsencesManager(IProfiCraftsmanEntities context): base(context){}

    }
}
