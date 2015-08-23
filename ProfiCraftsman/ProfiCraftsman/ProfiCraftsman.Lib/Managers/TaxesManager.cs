using CoreBase.Managers;
using ProfiCraftsman.Contracts;
using ProfiCraftsman.Contracts.Entities;
using ProfiCraftsman.Contracts.Managers;
using System;

namespace ProfiCraftsman.Lib.Managers
{
    public partial class TaxesManager: EntityManager<Taxes, int>
        ,ITaxesManager
    {

        public TaxesManager(IProfiCraftsmanEntities context): base(context){}

    }
}
