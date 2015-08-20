
using System;
using System.Collections.Generic;
using System.Linq;
using ProfiCraftsman.Contracts.Entities;

namespace ProfiCraftsman.Contracts.Managers
{
    public partial interface ITermsManager
    {
        IQueryable<Terms> GetActualTerms(DateTime dateFrom, DateTime dateTo);
    }
}
