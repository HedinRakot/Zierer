using CoreBase.Managers;
using ProfiCraftsman.Contracts;
using ProfiCraftsman.Contracts.Entities;
using ProfiCraftsman.Contracts.Managers;
using System;

namespace ProfiCraftsman.Lib.Managers
{
    public partial class RolePermissionRspManager: EntityManager<RolePermissionRsp, int>
        ,IRolePermissionRspManager
    {

        public RolePermissionRspManager(IProfiCraftsmanEntities context): base(context){}

    }
}
