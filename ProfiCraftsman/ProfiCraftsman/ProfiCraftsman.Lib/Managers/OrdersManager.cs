using CoreBase.Managers;
using ProfiCraftsman.Contracts;
using ProfiCraftsman.Contracts.Entities;
using ProfiCraftsman.Contracts.Managers;
using System;

namespace ProfiCraftsman.Lib.Managers
{
    public partial class OrdersManager: EntityManager<Orders, int>
        ,IOrdersManager
    {

        public OrdersManager(IProfiCraftsmanEntities context): base(context){}

    }
}
