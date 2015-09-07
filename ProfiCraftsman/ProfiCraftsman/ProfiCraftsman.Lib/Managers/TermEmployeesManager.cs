using CoreBase.Managers;
using ProfiCraftsman.Contracts;
using ProfiCraftsman.Contracts.Entities;
using ProfiCraftsman.Contracts.Managers;
using System;

namespace ProfiCraftsman.Lib.Managers
{
    public partial class TermEmployeesManager: EntityManager<TermEmployees, int>
        ,ITermEmployeesManager
    {

        public TermEmployeesManager(IProfiCraftsmanEntities context): base(context){}

    }
}
