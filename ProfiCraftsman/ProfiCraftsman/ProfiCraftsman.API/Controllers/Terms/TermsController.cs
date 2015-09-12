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
        protected ICustomProductsManager customProductManager { get; set; }

        public TermsController(ITermsManager manager, ICustomProductsManager customProductManager) : 
            base(manager)
        {
            this.customProductManager = customProductManager;
        }
        
        protected override void EntityToModel(Terms entity, TermsModel model)
        {
            model.orderId = entity.OrderId;
            model.employees = String.Join(", ", entity.TermEmployees.Where(e => !e.DeleteDate.HasValue).ToList().Select(o => o.Employees.Name + 
                (!String.IsNullOrEmpty(o.Employees.FirstName) ? " " + o.Employees.FirstName : String.Empty)));
            model.autoId = entity.AutoId;
            model.date = entity.Date;
            model.duration = entity.Duration;
            model.status = entity.TermStatusString;
            model.comment = entity.Comment;
            model.createDate = ((ISystemFields)entity).CreateDate;
            model.changeDate = ((ISystemFields)entity).ChangeDate;

            if(entity.TermEmployees.Where(e => !e.DeleteDate.HasValue).Count() == 0)
            {
                model.errorStatus += "Kein Mitarbeiter zugeordnet";
            }

            if (entity.TermPositions.Where(e => !e.DeleteDate.HasValue).Count() == 0)
            {
                if (!String.IsNullOrEmpty(model.errorStatus))
                {
                    model.errorStatus += ", ";
                }

                model.errorStatus += "Keine Position zugeordnet";
            }
        }

        protected override void ModelToEntity(TermsModel model, Terms entity, ActionTypes actionType)
        {
            entity.OrderId = model.orderId;
            entity.AutoId = model.autoId;
            entity.Date = model.date;
            entity.Duration = model.duration;
            entity.Comment = model.comment;

            if(actionType == ActionTypes.Add)
            {
                entity.TermCosts = new List<TermCosts>();
                foreach(var customProduct in customProductManager.GetEntities().Where(o => o.Auto).ToList())
                {
                    entity.TermCosts.Add(new TermCosts()
                    {
                        Terms = entity,
                        Name = customProduct.Name,
                        ProceedsAccountId = customProduct.ProceedsAccountId,
                        Price = customProduct.Price,
                        CreateDate = DateTime.Now,
                        ChangeDate = DateTime.Now,
                    });
                }
            }            
        }      
    }
}
