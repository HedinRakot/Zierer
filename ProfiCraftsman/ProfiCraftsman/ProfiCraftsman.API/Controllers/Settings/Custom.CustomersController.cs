﻿using ProfiCraftsman.API.Models.Settings;
using ProfiCraftsman.Contracts.Entities;
using System.Web.Http;
using CoreBase;
using System.Collections.Generic;
using System;
using CoreBase.Controllers;

namespace ProfiCraftsman.API.Controllers.Settings
{
    public partial class CustomersController
    {
        protected override string BuildWhereClause<T>(Filter filter)
        {
            if (filter.Field == "name")
            {
                var clauses = new List<string>();
                int number = 0;
                if (!String.IsNullOrEmpty(filter.Value))
                {
                    Int32.TryParse(filter.Value, out number);
                }

                clauses.AddRange(new[] {
                        base.BuildWhereClause<T>(new Filter { Field = "Name", Operator = filter.Operator, Value = filter.Value }),
                        base.BuildWhereClause<T>(new Filter { Field = "Street", Operator = filter.Operator, Value = filter.Value })
                    });

                return String.Format("{0}{1}", String.Join(" or ", clauses),
                    number != 0 ? String.Format(" or Number = {0} ", number) : String.Empty);
            }
            else if (filter.Field == "isProspectiveCustomerStatus")
            {
                int isProspectiveCustomerStatus;
                if (!String.IsNullOrEmpty(filter.Value))
                {
                    Int32.TryParse(filter.Value, out isProspectiveCustomerStatus);

                    return String.Format("IsProspectiveCustomer == {0}", isProspectiveCustomerStatus == 1 ? false : true);
                }
            }

            return base.BuildWhereClause<T>(filter);
        }
    }
}
