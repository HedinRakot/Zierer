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
    ///     Controller for Salary
    /// </summary>
    [AuthorizeByPermissions(PermissionTypes = new[] { Permissions.ProfitReports })]
    public partial class WorkHoursController : ApiController
    {
        protected ITermsManager termsManager { get; set; }
        protected IEmployeeRateRspManager employeeRateRspManager { get; set; }
        protected IEmployeesManager employeeManager { get; set; }

        public WorkHoursController(ITermsManager termsManager, IEmployeeRateRspManager employeeRateRspManager, IEmployeesManager employeeManager) 
        {
            this.termsManager = termsManager;
            this.employeeRateRspManager = employeeRateRspManager;
            this.employeeManager = employeeManager;
        }


        public virtual IHttpActionResult Get([FromUri] GridArgs args)
        {
            var entities = GetEntities(args.Filtering);

            if (entities == null)
            {
                var empty = new GridResult<WorkHoursModel, int>
                {
                    total = 0,
                    data = new List<WorkHoursModel>()
                };

                return Ok(empty);
            }

            var total = entities.Count();

            entities = Page(entities, args.Paging);

            var result = new GridResult<WorkHoursModel, int>
            {
                total = total,
                data = entities.ToList()
            };

            return Ok(result);
        }

        protected IEnumerable<WorkHoursModel> GetEntities(Filtering filtering)
        {
            var fromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            var toDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month));

            int? employeeId = null;
            GetFilters(filtering, ref fromDate, ref toDate, ref employeeId);
            var result = WorkHoursHelper.GetWorkHours(termsManager, employeeRateRspManager, employeeManager, fromDate, toDate, employeeId);

            return result.OrderByDescending(o => o.date);
        }
        
        private void GetFilters(Filtering filtering, ref DateTime fromDate, ref DateTime toDate, ref int? employeeId)
        {
            foreach (var compositeFilter in filtering.Filters)
            {
                foreach (var filter in compositeFilter.Filters)
                {
                    switch (filter.Field.ToLower())
                    {
                        case "fromdate":
                            DateTime.TryParse(filter.Value, out fromDate);
                            break;
                        case "todate":
                            DateTime.TryParse(filter.Value, out toDate);
                            break;
                        case "employeeid":
                            int temp;
                            if(Int32.TryParse(filter.Value, out temp))
                            {
                                employeeId = temp;
                            }
                            break;
                        default:
                            break;

                    }
                }
            }
        }

        private IEnumerable<WorkHoursModel> Page(IEnumerable<WorkHoursModel> entities, Paging paging)
        {
            if (paging.Take > 0)
            {
                entities = entities.Skip(paging.Skip).Take(paging.Take);
            }

            return entities;
        }
    }
}
