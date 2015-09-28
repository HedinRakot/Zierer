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
        public static IEnumerable<SalaryModel> GetSalary(ITermsManager termsManager, IEmployeeRateRspManager employeeRateRspManager, 
            IEmployeesManager employeeManager, DateTime fromDate, DateTime toDate)
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

            var workHours = WorkHoursHelper.GetWorkHours(termsManager, employeeRateRspManager, employeeManager, fromDate, toDate, null);

            foreach (var group in workHours.GroupBy(o => o.employeeId))
            {
                var model = result.FirstOrDefault(o => o.Id == group.Key);
                var amount = group.Sum(o => o.amount);
                if (model == null)
                {
                    model = new SalaryModel()
                    {
                        Id = group.Key,
                        employeeName = employees.FirstOrDefault(o => o.Id == group.Key).Name,
                        amountString = amount.ToString("N2") + " EUR",
                        amount = amount,
                    };

                    result.Add(model);
                }
                else
                {
                    model.amount += amount;
                    model.amountString = model.amount.ToString("N2") + " EUR";
                }
            }

            return result;
        }
    }
}
