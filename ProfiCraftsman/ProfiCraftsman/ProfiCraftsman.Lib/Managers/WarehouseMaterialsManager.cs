using CoreBase.Managers;
using ProfiCraftsman.Contracts;
using ProfiCraftsman.Contracts.Entities;
using ProfiCraftsman.Contracts.Managers;
using System;

namespace ProfiCraftsman.Lib.Managers
{
    public partial class WarehouseMaterialsManager: EntityManager<WarehouseMaterials, int>
        ,IWarehouseMaterialsManager
    {

        public WarehouseMaterialsManager(IProfiCraftsmanEntities context): base(context){}

    }
}
