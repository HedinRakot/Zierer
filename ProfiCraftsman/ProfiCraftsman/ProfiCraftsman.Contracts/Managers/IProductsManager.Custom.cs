
using System;
using System.Collections.Generic;
using System.Linq;
using ProfiCraftsman.Contracts.Entities;

namespace ProfiCraftsman.Contracts.Managers
{
    public partial interface IProductsManager
    {
        IQueryable<Positions> GetActualPositions(DateTime dateFrom, DateTime dateTo);

        IQueryable<Products> GetFreeProducts(IEnumerable<int> usedIds, int? productTypeId, string name, List<int> equipmentIds);

        List<Positions> GetRentPositions(DateTime dateFrom, DateTime dateTo, int? productTypeId, string name, IEnumerable<int> equipmentIds);
    }
}
