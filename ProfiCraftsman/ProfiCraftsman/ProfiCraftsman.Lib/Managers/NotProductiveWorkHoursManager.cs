using CoreBase.Managers;
using ProfiCraftsman.Contracts;
using ProfiCraftsman.Contracts.Entities;
using ProfiCraftsman.Contracts.Managers;
using System;

namespace ProfiCraftsman.Lib.Managers
{
    public partial class NotProductiveWorkHoursManager: EntityManager<NotProductiveWorkHours, int>
        ,INotProductiveWorkHoursManager
    {

        public NotProductiveWorkHoursManager(IProfiCraftsmanEntities context): base(context){}

    }
}
