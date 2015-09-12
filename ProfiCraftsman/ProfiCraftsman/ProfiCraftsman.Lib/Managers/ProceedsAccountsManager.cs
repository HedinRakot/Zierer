using CoreBase.Managers;
using ProfiCraftsman.Contracts;
using ProfiCraftsman.Contracts.Entities;
using ProfiCraftsman.Contracts.Managers;
using System;

namespace ProfiCraftsman.Lib.Managers
{
    public partial class ProceedsAccountsManager: EntityManager<ProceedsAccounts, int>
        ,IProceedsAccountsManager
    {

        public ProceedsAccountsManager(IProfiCraftsmanEntities context): base(context){}

    }
}
