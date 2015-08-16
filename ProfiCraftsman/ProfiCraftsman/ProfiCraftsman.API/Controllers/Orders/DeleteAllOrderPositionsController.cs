using ProfiCraftsman.API.Models;
using ProfiCraftsman.API.Models.Invoices;
using ProfiCraftsman.API.Security;
using ProfiCraftsman.Contracts.Entities;
using ProfiCraftsman.Contracts.Enums;
using ProfiCraftsman.Contracts.Managers;
using ProfiCraftsman.Contracts.Services;
using CoreBase;
using System;
using System.Web.Http;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ProfiCraftsman.API.Controllers
{
    [DataContract]
    public class DeleteAllPositionModel
    {
        [DataMember]
        public int id { get; set; }

        [DataMember]
        public bool isSellOrder { get; set; }
    }

    /// <summary>
    ///     Controller for close order
    /// </summary>
    [AuthorizeByPermissions(PermissionTypes = new[] { Permissions.Orders })]
    public partial class DeleteAllOrderPositionsController : ApiController
    {
        private readonly IOrdersManager manager;
        private readonly IPositionsManager positionManager;

        public DeleteAllOrderPositionsController(IOrdersManager manager, IPositionsManager positionManager)
        {
            this.manager = manager;
            this.positionManager = positionManager;
        }

        public IHttpActionResult Put(DeleteAllPositionModel model)
        {
            var order = manager.GetById(model.id);
            
            foreach(var position in order.Positions.Where(o => o.IsSellOrder == model.isSellOrder && !o.DeleteDate.HasValue).ToList())
            {
                positionManager.RemoveEntity(position);
            }

            positionManager.SaveChanges();

            return Ok(new { Result = "Ok" });
        }
    }
}
