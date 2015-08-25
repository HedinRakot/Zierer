using CoreBase.Managers;
using ProfiCraftsman.Contracts;
using ProfiCraftsman.Contracts.Entities;
using ProfiCraftsman.Contracts.Managers;
using System;

namespace ProfiCraftsman.Lib.Managers
{
    public partial class DeliveryNoteSignaturesManager: EntityManager<DeliveryNoteSignatures, int>
        ,IDeliveryNoteSignaturesManager
    {

        public DeliveryNoteSignaturesManager(IProfiCraftsmanEntities context): base(context){}

    }
}
