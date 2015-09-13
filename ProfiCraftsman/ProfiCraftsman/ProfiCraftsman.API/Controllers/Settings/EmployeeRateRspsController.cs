using CoreBase.Controllers;
using CoreBase.Entities;
using ProfiCraftsman.API.Models;
using ProfiCraftsman.API.Models.Settings;
using ProfiCraftsman.API.Security;
using ProfiCraftsman.Contracts;
using ProfiCraftsman.Contracts.Entities;
using ProfiCraftsman.Contracts.Enums;
using ProfiCraftsman.Contracts.Managers;
using System;

namespace ProfiCraftsman.API.Controllers.Settings
{
    /// <summary>
    ///     Controller for <see cref="EmployeeRateRsp"/> entity
    /// </summary>
    public partial class EmployeeRateRspsController: ClientApiController<EmployeeRateRspModel, EmployeeRateRsp, int, IEmployeeRateRspManager>
    {

        public EmployeeRateRspsController(IEmployeeRateRspManager manager): base(manager){}

        protected override void EntityToModel(EmployeeRateRsp entity, EmployeeRateRspModel model)
        {
            model.employeeId = entity.EmployeeId;
            model.jobPositionId = entity.JobPositionId;
            model.fromDate = entity.FromDate;
            model.toDate = entity.ToDate;
            model.salaryType = entity.SalaryType;
            model.salary = entity.Salary;
            model.createDate = ((ISystemFields)entity).CreateDate;
            model.changeDate = ((ISystemFields)entity).ChangeDate;
        }
        protected override void ModelToEntity(EmployeeRateRspModel model, EmployeeRateRsp entity, ActionTypes actionType)
        {
            entity.EmployeeId = model.employeeId;
            entity.JobPositionId = model.jobPositionId;
            entity.FromDate = model.fromDate;
            entity.ToDate = model.toDate;
            entity.SalaryType = model.salaryType;
            entity.Salary = model.salary;
        }
    }
}
