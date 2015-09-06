using CoreBase.Controllers;
using CoreBase.Entities;
using CoreBase.Exceptions;
using CoreBase.Models;
using ProfiCraftsman.API.Models;
using ProfiCraftsman.API.Models.Settings;
using ProfiCraftsman.API.Security;
using ProfiCraftsman.Contracts;
using ProfiCraftsman.Contracts.Entities;
using ProfiCraftsman.Contracts.Enums;
using ProfiCraftsman.Contracts.Managers;
using ProfiCraftsman.Lib.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Web.Http;

namespace ProfiCraftsman.API.Controllers
{
    /// <summary>
    ///     Controller for <see cref="Terms"/> entity
    /// </summary>
    [AuthorizeByPermissions(PermissionTypes = new[] { Permissions.Orders })]
    public partial class TripsController : ReadOnlyClientApiController<TripsModel, Terms, int, ITermsManager>
    {
        public TripsController(ITermsManager manager) : 
            base(manager)
        {

        }
        
        protected override void EntityToModel(Terms entity, TripsModel model)
        {
            model.employees = String.Join(", ", entity.TermEmployees.ToList().Select(o => o.Employees.Name + 
                (!String.IsNullOrEmpty(o.Employees.FirstName) ? " " + o.Employees.FirstName : String.Empty)));
            model.autoId = entity.AutoId;
            model.date = entity.Date;
            model.duration = entity.BeginTrip.HasValue && entity.EndTrip.HasValue ? entity.EndTrip.Value - entity.BeginTrip.Value : TimeSpan.Zero;
            model.returnWayDuration = entity.BeginReturnTrip.HasValue && entity.EndReturnTrip.HasValue ? 
                entity.EndReturnTrip.Value - entity.BeginReturnTrip.Value : TimeSpan.Zero;

            model.createDate = ((ISystemFields)entity).CreateDate;
            model.changeDate = ((ISystemFields)entity).ChangeDate;            
        }
        
        protected override string BuildWhereClause<T>(Filter filter)
        {
            if (filter.Field == "isGreaterAsDefaultStatus")
            {
                int isGreaterAsDefaultStatus;
                if (!String.IsNullOrEmpty(filter.Value))
                {
                    Int32.TryParse(filter.Value, out isGreaterAsDefaultStatus);

                    return String.Format("{0}", isGreaterAsDefaultStatus == 1 ? " 1 == 1" : 
                        String.Format(" (EndTrip.HasValue && BeginTrip.HasValue && (DbFunctions.DiffMinutes(BeginTrip, EndTrip) > {0} || DbFunctions.DiffMinutes(BeginReturnTrip, EndReturnTrip) > {0}))",
                        30));
                }
            }

            return base.BuildWhereClause<T>(filter);
        }
    }
}
