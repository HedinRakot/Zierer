using CoreBase.Managers;
using ProfiCraftsman.Contracts;
using ProfiCraftsman.Contracts.Entities;
using ProfiCraftsman.Contracts.Managers;
using System;

namespace ProfiCraftsman.Lib.Managers
{
    public partial class OrderFilesManager: EntityManager<OrderFiles, int>
        ,IOrderFilesManager
    {

        public OrderFilesManager(IProfiCraftsmanEntities context): base(context){}

    }
}
