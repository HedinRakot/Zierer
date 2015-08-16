﻿using ProfiCraftsman.API.Models.Settings;
using ProfiCraftsman.Contracts.Entities;
using System.Web.Http;
using CoreBase;
using System.Collections.Generic;
using CoreBase.Controllers;

namespace ProfiCraftsman.API.Controllers.Settings
{
    public partial class EquipmentsController
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

            return base.BuildWhereClause<T>(filter);
        }
    }
}
