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
    public class DeleteAllTermPositionModel
    {
        [DataMember]
        public int id { get; set; }
    }

    /// <summary>
    ///     Controller for close order
    /// </summary>
    [AuthorizeByPermissions(PermissionTypes = new[] { Permissions.Orders })]
    public partial class DeleteAllTermPositionsController : ApiController
    {
        private readonly ITermsManager manager;
        private readonly ITermPositionsManager positionManager;

        public DeleteAllTermPositionsController(ITermsManager manager, ITermPositionsManager positionManager)
        {
            this.manager = manager;
            this.positionManager = positionManager;
        }

        public IHttpActionResult Put(DeleteAllPositionModel model)
        {
            var term = manager.GetById(model.id);
            
            foreach(var position in term.TermPositions.ToList())
            {
                positionManager.RemoveEntity(position);
            }

            positionManager.SaveChanges();

            return Ok(new { Result = "Ok" });
        }
    }
}
