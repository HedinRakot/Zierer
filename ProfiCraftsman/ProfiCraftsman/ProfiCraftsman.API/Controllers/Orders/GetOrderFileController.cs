using CoreBase.ActionResults;
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
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace ProfiCraftsman.API.Controllers
{
    /// <summary>
    ///     Controller for <see cref="OrderFiles"/> entity
    /// </summary>
    [AuthorizeByPermissions(PermissionTypes = new[] { Permissions.Orders })]
    public partial class GetOrderFileController : ApiController
    {
        protected IOrderFilesManager manager { get; set; }
        public GetOrderFileController(IOrderFilesManager manager)
        {
            this.manager = manager;
        }
        
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var orderFile = manager.GetById(id);
            if (orderFile == null || String.IsNullOrWhiteSpace(orderFile.FileName))
                return NotFound();

            return new FileActionResult(orderFile.FileName, Path.GetFileName(orderFile.FileName));
        }
    }
}
