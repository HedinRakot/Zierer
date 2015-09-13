using ProfiCraftsman.Contracts.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace ProfiCraftsman.Contracts.Entities
{
    /// <summary>
    ///  Employees
    /// </summary>
    public partial class EmployeeRateRsp
    {
        public SalaryTypes SalaryTypes
        {
            get
            {
                return (SalaryTypes)SalaryType;
            }
        }

        public string SalaryTypesString
        {
            get
            {
                var result = String.Empty;

                switch(SalaryTypes)
                {
                    case SalaryTypes.Monthly:
                        result = "Monatseinkommen";
                        break;
                    case SalaryTypes.Hour:
                        result = "Stundensatz";
                        break;
                }

                return result;
            }
        }
    }
}
