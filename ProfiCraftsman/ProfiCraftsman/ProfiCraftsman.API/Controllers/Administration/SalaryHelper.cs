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
    /// Salary Helper
    /// </summary>
    public static class SalaryHelper
    {
        public static IEnumerable<SalaryModel> GetSalary(IEmployeeRateRspManager employeeRateRspManager, IEmployeesManager employeeManager,
            DateTime fromDate, DateTime toDate)
        {
            var result = new List<SalaryModel>();

            var rates = employeeRateRspManager.GetEntities(o => o.SalaryTypes == SalaryTypes.Monthly).ToList(); //TODO delete check ?
            var employees = employeeManager.GetEntities().ToList();

            foreach (var employee in employees)
            {
                double amount = 0;
                for (var date = fromDate; date < toDate; date = date.AddMonths(1))
                {
                    var rate = rates.Where(o => o.EmployeeId == employee.Id && o.FromDate <= date && date <= o.ToDate).FirstOrDefault();
                    
                    if(rate != null)
                    {
                        amount += rate.Salary;
                    }
                }

                result.Add(new SalaryModel()
                {
                    Id = employee.Id,
                    employeeName = employee.Name,
                    amountString = amount.ToString("N2") + " EUR",
                    amount = amount,
                });
            }

            return result;
        }
    }
}
