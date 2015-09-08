using CoreBase.Managers;
using ProfiCraftsman.Contracts;
using ProfiCraftsman.Contracts.Entities;
using ProfiCraftsman.Contracts.Managers;
using System;

namespace ProfiCraftsman.Lib.Managers
{
    public partial class EmployeeRateRspManager: EntityManager<EmployeeRateRsp, int>
        ,IEmployeeRateRspManager
    {

        public EmployeeRateRspManager(IProfiCraftsmanEntities context): base(context){}

    }
}
