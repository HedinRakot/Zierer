using ProfiCraftsman.API.Models.Settings;
using ProfiCraftsman.Contracts.Entities;
using System.Web.Http;
using CoreBase;
using System.Collections.Generic;
using CoreBase.Controllers;
using System;

namespace ProfiCraftsman.API.Controllers.Settings
{
    public partial class AdditionalCostsController
    {
        protected override string BuildWhereClause<T>(Filter filter)
        {
            if (filter.Field == "name")
            {
                var clauses = new List<string>();

                clauses.AddRange(new[] {
                        base.BuildWhereClause<T>(new Filter { Field = "Description", Operator = filter.Operator,
                            Value = filter.Value }),
                    });

                return string.Join(" or ", clauses);
            }
            else if (filter.Field == "toDate")
            {
                DateTime toDate;
                DateTime.TryParse(filter.Value, out toDate);
                return String.Format(" {0}", toDate == DateTime.MinValue ? "1 == 1" :
                    String.Format("((!ToDate.HasValue || ToDate.Value >=  DateTime({0}, {1}, {2})) && FromDate <= DateTime({0}, {1}, {2}))", toDate.Year, toDate.Month, toDate.Day));
            }

            return base.BuildWhereClause<T>(filter);
        }
    }
}
