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
    ///     Controller for <see cref="Terms"/> entity
    /// </summary>
    [AuthorizeByPermissions(PermissionTypes = new[] { Permissions.Orders })]
    public partial class TermsController : ClientApiController<TermsModel, Terms, int, ITermsManager>
    {
        public TermsController(ITermsManager manager) : 
            base(manager)
        {

        }
        
        protected override void EntityToModel(Terms entity, TermsModel model)
        {
            model.orderId = entity.OrderId;
            model.employeeId = entity.EmployeeId;
            model.autoId = entity.AutoId;
            model.date = entity.Date;
            model.duration = entity.Duration;
            model.status = entity.TermStatusString;
            model.comment = entity.Comment;
            model.createDate = ((ISystemFields)entity).CreateDate;
            model.changeDate = ((ISystemFields)entity).ChangeDate;
        }

        protected override void ModelToEntity(TermsModel model, Terms entity, ActionTypes actionType)
        {
            entity.OrderId = model.orderId;
            entity.EmployeeId = model.employeeId;
            entity.AutoId = model.autoId;
            entity.Date = model.date;
            entity.Duration = model.duration;
            entity.Comment = model.comment;

            if(actionType == ActionTypes.Add)
            {

            }            
        }      
    }
}
