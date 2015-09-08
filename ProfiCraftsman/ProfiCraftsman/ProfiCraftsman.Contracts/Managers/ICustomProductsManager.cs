using CoreBase.Entities;
using CoreBase.ManagerInterfaces;
using ProfiCraftsman.Contracts.Entities;
using System;

namespace ProfiCraftsman.Contracts.Managers
{
    public partial interface ICustomProductsManager: IEntityManager<CustomProducts, int>
    {
    }
}
