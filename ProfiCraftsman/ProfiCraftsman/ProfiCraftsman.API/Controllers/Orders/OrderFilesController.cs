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
using System.IO;
using System.Linq;
using System.Linq.Dynamic;
using System.Web;
using System.Web.Http;

namespace ProfiCraftsman.API.Controllers
{
    /// <summary>
    ///     Controller for <see cref="OrderFiles"/> entity
    /// </summary>
    [AuthorizeByPermissions(PermissionTypes = new[] { Permissions.Orders })]
    public partial class OrderFilesController : ClientApiController<OrderFilesModel, OrderFiles, int, IOrderFilesManager>
    {
        public OrderFilesController(IOrderFilesManager manager) : 
            base(manager)
        {
        }

        protected override void EntityToModel(OrderFiles entity, OrderFilesModel model)
        {
            model.orderId = entity.OrderId;
            model.filePath = Path.Combine(VirtualPathUtility.ToAbsolute("~/App_Data/OrderFiles"), 
                entity.OrderId.ToString(),
                Path.GetFileName(entity.FileName));
            model.comment = entity.Comment;
            model.fileName = Path.GetFileName(entity.FileName);
        }

        protected override void ModelToEntity(OrderFilesModel model, OrderFiles entity, ActionTypes actionType)
        {
            entity.OrderId = model.orderId;
            entity.Comment = model.comment;

            if(actionType == ActionTypes.Add)
            {
                entity.FileName = model.fileName;
            }
        }      
    }
}
