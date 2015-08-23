using CoreBase.Managers;
using ProfiCraftsman.Contracts;
using ProfiCraftsman.Contracts.Entities;
using ProfiCraftsman.Contracts.Managers;
using System;

namespace ProfiCraftsman.Lib.Managers
{
    public partial class UserManager: EntityManager<User, int>
        ,IUserManager
    {

        public UserManager(IProfiCraftsmanEntities context): base(context){}

    }
}
