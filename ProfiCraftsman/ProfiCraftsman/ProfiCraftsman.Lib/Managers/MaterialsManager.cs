using CoreBase.Managers;
using ProfiCraftsman.Contracts;
using ProfiCraftsman.Contracts.Entities;
using ProfiCraftsman.Contracts.Managers;
using System;

namespace ProfiCraftsman.Lib.Managers
{
    public partial class MaterialsManager: EntityManager<Materials, int>
        ,IMaterialsManager
    {

        public MaterialsManager(IProfiCraftsmanEntities context): base(context){}

    }
}
