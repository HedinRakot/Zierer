using CoreBase.Managers;
using ProfiCraftsman.Contracts;
using ProfiCraftsman.Contracts.Entities;
using ProfiCraftsman.Contracts.Managers;
using System;

namespace ProfiCraftsman.Lib.Managers
{
    public partial class SearchPositionViewManager: EntityManager<SearchPositionView, int>
        ,ISearchPositionViewManager
    {

        public SearchPositionViewManager(IProfiCraftsmanEntities context): base(context){}

    }
}
