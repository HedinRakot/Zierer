using ProfiCraftsman.API.Models.Settings;
using ProfiCraftsman.Contracts.Entities;
using System.Web.Http;
using CoreBase;
using System.Collections.Generic;
using ProfiCraftsman.Contracts.Managers;
using CoreBase.Controllers;
using System.Linq;
using System;

namespace ProfiCraftsman.API.Controllers.Settings
{
    public partial class InstrumentsController
    {
        protected void ExtraEntityToModel(Instruments entity, InstrumentsModel model)
        {
            var termInstrument = entity.TermInstruments.Where(o => !o.DeleteDate.HasValue).LastOrDefault();
            model.employeeName = termInstrument != null ? termInstrument.Employees.Name : string.Empty;
        }

        protected override string BuildWhereClause<T>(Filter filter)
        {
            if (filter.Field == "name")
            {
                var clauses = new List<string>();

                clauses.AddRange(new[] {
                        base.BuildWhereClause<T>(new Filter { Field = "Name", Operator = filter.Operator, Value = filter.Value }),
                        base.BuildWhereClause<T>(new Filter { Field = "Number", Operator = filter.Operator, Value = filter.Value }),
                    });

                return string.Join(" or ", clauses);
            }
            else if (filter.Field == "fromDate")
            {
                DateTime fromDate;
                DateTime.TryParse(filter.Value, out fromDate);
                return String.Format(" {0}", fromDate == DateTime.MinValue ? "1 == 1" :
                    String.Format("(ChangeDate >= DateTime({0}, {1}, {2}))", fromDate.Year, fromDate.Month, fromDate.Day));
            }
            else if (filter.Field == "toDate")
            {
                DateTime toDate;
                DateTime.TryParse(filter.Value, out toDate);
                return String.Format(" {0}", toDate == DateTime.MinValue ? "1 == 1" :
                    String.Format("(ChangeDate <= DateTime({0}, {1}, {2}))", toDate.Year, toDate.Month, toDate.Day));
            }

            return base.BuildWhereClause<T>(filter);
        }
    }
}
