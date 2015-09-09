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
    ///     Controller for <see cref="TermCosts"/> entity
    /// </summary>
    [AuthorizeByPermissions(PermissionTypes = new[] { Permissions.Orders })]
    public partial class TermCostsController : ClientApiController<TermCostsModel, TermCosts, int, ITermCostsManager>
    {

        public TermCostsController(ITermCostsManager manager) : 
            base(manager)
        {
        }

        protected override void EntityToModel(TermCosts entity, TermCostsModel model)
        {
            model.termId = entity.TermId;
            model.price = entity.Price;
            model.name = entity.Name;
            model.createDate = ((ISystemFields)entity).CreateDate;
            model.changeDate = ((ISystemFields)entity).ChangeDate;
        }

        protected override void ModelToEntity(TermCostsModel model, TermCosts entity, ActionTypes actionType)
        {
            entity.TermId = model.termId;
            entity.Price = model.price;
            entity.Name = model.name;

            entity.ChangeDate = DateTime.Now;

            if(actionType == ActionTypes.Add)
            {
                entity.CreateDate = DateTime.Now;
            }
        }      
    }
}
