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
    ///     Controller for <see cref="TermInstruments"/> entity
    /// </summary>
    [AuthorizeByPermissions(PermissionTypes = new[] { Permissions.Orders })]
    public partial class TermEmployeesController : ClientApiController<TermEmployeeModel, TermEmployees, int, ITermEmployeesManager>
    {

        public TermEmployeesController(ITermEmployeesManager manager) : 
            base(manager)
        {
        }

        protected override void EntityToModel(TermEmployees entity, TermEmployeeModel model)
        {
            model.termId = entity.TermId;
            model.employeeId = entity.EmployeeId;
            model.createDate = ((ISystemFields)entity).CreateDate;
            model.changeDate = ((ISystemFields)entity).ChangeDate;
        }

        protected override void ModelToEntity(TermEmployeeModel model, TermEmployees entity, ActionTypes actionType)
        {
            entity.TermId = model.termId;
            entity.EmployeeId = model.employeeId;
        }      
    }
}
