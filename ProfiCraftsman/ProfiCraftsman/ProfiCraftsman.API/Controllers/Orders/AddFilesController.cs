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
using ProfiCraftsman.API.Models.Settings;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;
using System.Web;
using System.IO;
using System.Net.Http.Headers;
using MultipartFormDataStreamProvider = ProfiCraftsman.API.Controllers.MultipartFormDataStreamProvider;
using ProfiCraftsman.Lib.Import;

namespace ProfiCraftsman.API.Controllers
{
    /// <summary>
    ///     Controller for import materials
    /// </summary>
    [AuthorizeByPermissions(PermissionTypes = new[] { Permissions.Orders })]
    public partial class AddOrderFilesController : ApiController
    {
        private readonly IOrderFilesManager manager;

        public AddOrderFilesController(IOrderFilesManager manager)
        {
            this.manager = manager;
            Folder = HttpContext.Current.Server.MapPath("~/App_Data/OrderFiles");
        }

        private string Folder { get; set; }

        [HttpPost]
        public async Task<IHttpActionResult> Post(int orderId)
        {
            // Check if the request contains multipart/form-data.
            if (!Request.Content.IsMimeMultipartContent())
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);

            var provider = new MultipartFormDataStreamProvider(Folder);
            string filePath = null;

            try
            {
                // Read the form data.
                await Request.Content.ReadAsMultipartAsync(provider);
                var fileData = provider.FileData[0];
                filePath = Path.Combine(Folder, fileData.LocalFileName);


                var orderFolder = Path.Combine(Folder, orderId.ToString());
                if (!Directory.Exists(orderFolder))
                {
                    Directory.CreateDirectory(orderFolder);
                }

                var newFilePath = Path.Combine(orderFolder, Path.GetFileName(filePath));
                File.Copy(filePath, newFilePath);

                manager.AddEntity(new OrderFiles()
                {
                    OrderId = orderId,
                    FileName = newFilePath,
                });

                manager.SaveChanges();

                return Ok(new
                {

                });
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
            finally
            {
                if (!String.IsNullOrWhiteSpace(filePath) && File.Exists(filePath))
                    File.Delete(filePath);
            }
        }
    }
}
