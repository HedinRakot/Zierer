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
    [AuthorizeByPermissions(PermissionTypes = new[] { Permissions.Employees })]
    /// <summary>
    ///     Controller for <see cref="Employees"/> entity
    /// </summary>
    public partial class EmployeesController: ClientApiController<EmployeesModel, Employees, int, IEmployeesManager>
    {

        public EmployeesController(IEmployeesManager manager): base(manager){}

        protected override void EntityToModel(Employees entity, EmployeesModel model)
        {
            model.number = entity.Number;
            model.jobPositionId = entity.JobPositionId;
            model.autoId = entity.AutoId;
            model.name = entity.Name;
            model.firstName = entity.FirstName;
            model.street = entity.Street;
            model.zip = entity.Zip;
            model.city = entity.City;
            model.country = entity.Country;
            model.phone = entity.Phone;
            model.mobile = entity.Mobile;
            model.fax = entity.Fax;
            model.email = entity.Email;
            model.comment = entity.Comment;
            model.createDate = ((ISystemFields)entity).CreateDate;
            model.changeDate = ((ISystemFields)entity).ChangeDate;
        }
        protected override void ModelToEntity(EmployeesModel model, Employees entity, ActionTypes actionType)
        {
            entity.Number = model.number;
            entity.JobPositionId = model.jobPositionId;
            entity.AutoId = model.autoId;
            entity.Name = model.name;
            entity.FirstName = model.firstName;
            entity.Street = model.street;
            entity.Zip = model.zip;
            entity.City = model.city;
            entity.Country = model.country;
            entity.Phone = model.phone;
            entity.Mobile = model.mobile;
            entity.Fax = model.fax;
            entity.Email = model.email;
            entity.Comment = model.comment;
        }
    }
}
