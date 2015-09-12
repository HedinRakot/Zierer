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
    public partial class EmployeesController
    {
        protected void ExtraEntityToModel(Employees entity, EmployeesModel model)
        {
            var jobPosition = entity.EmployeeRateRsps.Where(o => !o.DeleteDate.HasValue && o.FromDate.Date <= DateTime.Now.Date && DateTime.Now.Date <= o.ToDate.Date).LastOrDefault();
            model.jobPosition = jobPosition != null ? jobPosition.JobPositions.Name : string.Empty;
        }
    }
}
