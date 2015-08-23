using CoreBase.Managers;
using ProfiCraftsman.Contracts;
using ProfiCraftsman.Contracts.Entities;
using ProfiCraftsman.Contracts.Managers;
using System;

namespace ProfiCraftsman.Lib.Managers
{
    public partial class CommunicationPartnersManager: EntityManager<CommunicationPartners, int>
        ,ICommunicationPartnersManager
    {

        public CommunicationPartnersManager(IProfiCraftsmanEntities context): base(context){}

    }
}
