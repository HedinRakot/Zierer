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
    public class ProfitReportsSearchModel
    {
        public DateTime? FromDate { get; set; }

        public DateTime? ToDate { get; set; }
    }


    /// <summary>
    ///     Controller for profit reports
    /// </summary>
    [AuthorizeByPermissions(PermissionTypes = new[] { Permissions.ProfitReports })]
    public partial class ProfitReportsController : ApiController
    {
        protected IAdditionalCostsManager additionalCostsManager { get; set; }

        public ProfitReportsController(IAdditionalCostsManager additionalCostsManager)
        {
            this.additionalCostsManager = additionalCostsManager;
        }


        public IHttpActionResult Post(ProfitReportsSearchModel model)
        {
            var additionalCosts = additionalCostsManager.GetEntities();
            if(model.FromDate.HasValue)
            {
                additionalCosts = additionalCosts.Where(o => o.FromDate >= model.FromDate.Value);
            }

            if (model.ToDate.HasValue)
            {
                additionalCosts = additionalCosts.Where(o => (!o.ToDate.HasValue || o.ToDate.Value >= model.ToDate.Value) && o.FromDate <= model.ToDate.Value);
            }

            var additionalCostsSum = additionalCosts.Sum(o => o.Price);

            return Ok(new { additionalCostsSum = additionalCostsSum.ToString("N2") + " EUR" });
        }
    }
}
