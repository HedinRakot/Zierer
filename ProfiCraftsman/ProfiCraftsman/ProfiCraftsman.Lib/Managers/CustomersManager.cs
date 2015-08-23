using CoreBase.Managers;
using ProfiCraftsman.Contracts;
using ProfiCraftsman.Contracts.Entities;
using ProfiCraftsman.Contracts.Managers;
using System;

namespace ProfiCraftsman.Lib.Managers
{
    public partial class CustomersManager: EntityManager<Customers, int>
        ,ICustomersManager
    {

        public CustomersManager(IProfiCraftsmanEntities context): base(context){}

    }
}
