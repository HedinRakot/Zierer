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
    public class MultipartFormDataStreamProvider : System.Net.Http.MultipartFormDataStreamProvider
    {
        public MultipartFormDataStreamProvider(string root)
            : base(root)
        {

        }

        public override string GetLocalFileName(HttpContentHeaders headers)
        {
            var fileName = headers.ContentDisposition.FileName.Replace("\"", string.Empty);

            return Guid.NewGuid().ToString() + "-" + fileName;
        }
    }

    /// <summary>
    ///     Controller for import materials
    /// </summary>
    [AuthorizeByPermissions(PermissionTypes = new[] { Permissions.Materials })]
    public partial class ImportMaterialsController : ApiController
    {
        private readonly IMaterialsManager manager;

        public ImportMaterialsController(IMaterialsManager manager)
        {
            this.manager = manager;
            Folder = HttpContext.Current.Server.MapPath("~/App_Data/MaterialImport");
        }

        private string Folder { get; set; }

        [HttpPost]
        public async Task<IHttpActionResult> Post()
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
                MaterialImportResults results = null;

                using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    var importer = new MaterialImporter(manager);
                    results = await importer.ImportFromStream(stream);

                    stream.Close();
                }

                //foreach (var question in results.CreatedQuestions)
                //    await Logger.AddInformation(" \"{0}\" был добавлен в результате импорта.", .Name);

                //foreach (var question in results.UpdatedQuestions)
                //    await Logger.AddInformation(" \"{0}\" был обновлен в результате импорта.", .Name);

                return Ok(new
                {
                    CreatedMaterials = results.CreatedMaterials.Count,
                    UpdatedMaterials = results.UpdatedMaterials.Count,
                    Errors = results.Errors,
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
