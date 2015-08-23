using CoreBase.Managers;
using ProfiCraftsman.Contracts;
using ProfiCraftsman.Contracts.Entities;
using ProfiCraftsman.Contracts.Managers;
using System;

namespace ProfiCraftsman.Lib.Managers
{
    public partial class RoleManager: EntityManager<Role, int>
        ,IRoleManager
    {

        public RoleManager(IProfiCraftsmanEntities context): base(context){}

    }
}
