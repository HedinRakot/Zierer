using CoreBase.Managers;
using ProfiCraftsman.Contracts;
using ProfiCraftsman.Contracts.Entities;
using ProfiCraftsman.Contracts.Managers;
using System;

namespace ProfiCraftsman.Lib.Managers
{
    public partial class EmployeesManager: EntityManager<Employees, int>
        ,IEmployeesManager
    {

        public EmployeesManager(IProfiCraftsmanEntities context): base(context){}

    }
}
