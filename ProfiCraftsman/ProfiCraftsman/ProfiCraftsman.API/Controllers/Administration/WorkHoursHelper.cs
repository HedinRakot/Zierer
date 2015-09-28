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
    /// Work Hours Helper
    /// </summary>
    public static class WorkHoursHelper
    {
        public static IEnumerable<WorkHoursModel> GetWorkHours(ITermsManager termsManager, IEmployeeRateRspManager employeeRateRspManager,
            IEmployeesManager employeeManager,
            DateTime fromDate, DateTime toDate, int? employeeId)
        {
            var result = new List<WorkHoursModel>();

            var rates = employeeRateRspManager.GetEntities(o => o.SalaryTypes == SalaryTypes.Hour).ToList();
            var employees = employeeManager.GetEntities().ToList();

            var terms = termsManager.GetEntities(o => o.Date >= fromDate && o.Date <= toDate).ToList();

            foreach (var term in terms)
            {
                var termEmployees = term.TermEmployees.Where(o => !o.DeleteDate.HasValue);
                if (employeeId.HasValue)
                {
                    termEmployees = termEmployees.Where(o => o.EmployeeId == employeeId.Value);
                }

                foreach (var termEmployee in termEmployees.ToList())
                {
                    var rate = rates.Where(o => o.EmployeeId == termEmployee.EmployeeId && o.FromDate <= term.Date && term.Date <= o.ToDate).FirstOrDefault();
                    double amount = 0;

                    var startTime = term.Date;
                    var endTime = term.Date.AddMinutes(term.Duration);

                    if (term.BeginTrip.HasValue)
                    {
                        startTime = term.BeginTrip.Value;
                    }

                    if(term.EndReturnTrip.HasValue)
                    {
                        endTime = term.EndReturnTrip.Value;
                    }
                    else if(term.EndWork.HasValue)
                    {
                        endTime = term.EndWork.Value;
                    }

                    var duration = Math.Round((endTime - startTime).TotalMinutes);

                    if(rate != null)
                    {
                        amount = (rate.Salary / (double)60) * duration;
                    }

                    result.Add(new WorkHoursModel()
                    {
                        Id = termEmployee.Id,
                        employeeId = termEmployee.EmployeeId,
                        employeeName = termEmployee.Employees.Name,
                        amountString = amount.ToString("N2") + " EUR",
                        amount = amount,
                        duration = String.Format("{0} Min.", duration),
                        date = term.Date,
                    });
                }
            }

            return result;
        }
    }
}
