
using System;
using System.Collections.Generic;
using System.Linq;
using ProfiCraftsman.Contracts.Entities;
using ProfiCraftsman.Contracts.Enums;

namespace ProfiCraftsman.Lib.Managers
{
    public partial class TermsManager
    {
        public IQueryable<Terms> GetActualTerms()
        {
            return DataContext.GetSet<Terms>()
                .Where(r =>
                    !r.DeleteDate.HasValue &&
                    r.Status != (int)TermStatusTypes.Canceled
                );
        }

        public IQueryable<Terms> GetActualTerms(DateTime dateFrom, DateTime dateTo)
        {
            return GetActualTerms().
                Where(r =>
                    (dateFrom <= r.Date && r.Date <= dateTo)).AsQueryable(); //period is a part of an existing one
        }
    }
}
