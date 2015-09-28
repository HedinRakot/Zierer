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
    public partial class SalaryController: ApiController
    {
        protected IEmployeeRateRspManager employeeRateRspManager { get; set; }
        protected IEmployeesManager employeeManager { get; set; }
        protected ITermsManager termsManager { get; set; }

        public SalaryController(IEmployeeRateRspManager employeeRateRspManager, IEmployeesManager employeeManager, ITermsManager termsManager) 
        {
            this.employeeRateRspManager = employeeRateRspManager;
            this.employeeManager = employeeManager;
            this.termsManager = termsManager;
        }


        public virtual IHttpActionResult Get([FromUri] GridArgs args)
        {
            var entities = GetEntities(args.Filtering);

            if (entities == null)
            {
                var empty = new GridResult<SalaryModel, int>
                {
                    total = 0,
                    data = new List<SalaryModel>()
                };

                return Ok(empty);
            }

            var total = entities.Count();

            entities = Page(entities, args.Paging);

            var result = new GridResult<SalaryModel, int>
            {
                total = total,
                data = entities.ToList()
            };

            return Ok(result);
        }

        protected IEnumerable<SalaryModel> GetEntities(Filtering filtering)
        {
            var fromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            var toDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month));

            GetFilters(filtering, ref fromDate, ref toDate);
            var result = SalaryHelper.GetSalary(termsManager, employeeRateRspManager, employeeManager, fromDate, toDate);

            return result;
        }
        
        private void GetFilters(Filtering filtering, ref DateTime fromDate, ref DateTime toDate)
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
                        default:
                            break;

                    }
                }
            }
        }

        private IEnumerable<SalaryModel> Page(IEnumerable<SalaryModel> entities, Paging paging)
        {
            if (paging.Take > 0)
            {
                entities = entities.Skip(paging.Skip).Take(paging.Take);
            }

            return entities;
        }
    }
}
