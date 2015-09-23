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
}
