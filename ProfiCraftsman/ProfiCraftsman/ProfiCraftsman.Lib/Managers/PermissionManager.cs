using CoreBase.Managers;
using ProfiCraftsman.Contracts;
using ProfiCraftsman.Contracts.Entities;
using ProfiCraftsman.Contracts.Managers;
using System;

namespace ProfiCraftsman.Lib.Managers
{
    public partial class PermissionManager: EntityManager<Permission, int>
        ,IPermissionManager
    {

        public PermissionManager(IProfiCraftsmanEntities context): base(context){}

    }
}
