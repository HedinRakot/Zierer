using CoreBase.Managers;
using ProfiCraftsman.Contracts;
using ProfiCraftsman.Contracts.Entities;
using ProfiCraftsman.Contracts.Managers;
using System;

namespace ProfiCraftsman.Lib.Managers
{
    public partial class MaterialDeliveryRspManager: EntityManager<MaterialDeliveryRsp, int>
        ,IMaterialDeliveryRspManager
    {

        public MaterialDeliveryRspManager(IProfiCraftsmanEntities context): base(context){}

    }
}
