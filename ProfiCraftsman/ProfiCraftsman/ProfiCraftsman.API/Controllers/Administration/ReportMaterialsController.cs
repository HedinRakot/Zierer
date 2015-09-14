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
    ///     Controller for Salary
    /// </summary>
    [AuthorizeByPermissions(PermissionTypes = new[] { Permissions.ProfitReports })]
    public partial class ReportMaterialsController: ApiController
    {
        protected IMaterialDeliveryRspManager materialDeliveryRspManager { get; set; }

        public ReportMaterialsController(IMaterialDeliveryRspManager materialDeliveryRspManager) 
        {
            this.materialDeliveryRspManager = materialDeliveryRspManager;
        }


        public virtual IHttpActionResult Get([FromUri] GridArgs args)
        {
            var entities = GetEntities(args.Filtering);

            if (entities == null)
            {
                var empty = new GridResult<ReportMaterialModel, int>
                {
                    total = 0,
                    data = new List<ReportMaterialModel>()
                };

                return Ok(empty);
            }

            var total = entities.Count();

            entities = Page(entities, args.Paging);

            var result = new GridResult<ReportMaterialModel, int>
            {
                total = total,
                data = entities.ToList()
            };

            return Ok(result);
        }

        protected IEnumerable<ReportMaterialModel> GetEntities(Filtering filtering)
        {
            var fromDate = DateTime.Now.Date;
            var toDate = DateTime.Now.Date;

            GetFilters(filtering, ref fromDate, ref toDate);
            var result = new List<ReportMaterialModel>();

            var materials = materialDeliveryRspManager.GetEntities(o => o.CreateDate.Date >= fromDate && o.CreateDate.Date <= toDate).ToList();
            foreach(var materialGroup in materials.GroupBy(o => o.Materials))
            {
                var amount = materialGroup.Sum(o => o.Amount);
                result.Add(new ReportMaterialModel()
                {
                    Id = materialGroup.Key.Id,
                    materialName = materialGroup.Key.Name,
                    materialNumber = materialGroup.Key.Number,
                    amount = amount,
                    price = (amount * materialGroup.Key.Price).ToString("N2") + " EUR",
                });
            }

            return result;
        }
        
        private void GetFilters(Filtering filtering, ref DateTime fromDate, ref DateTime toDate)
        {
            foreach (var compositeFilter in filtering.Filters)
            {
                foreach (var filter in compositeFilter.Filters)
                {
                    switch (filter.Field.ToLower())
                    {
                        case "fromdate":
                            DateTime.TryParse(filter.Value, out fromDate);
                            break;
                        case "todate":
                            DateTime.TryParse(filter.Value, out toDate);
                            break;
                        default:
                            break;

                    }
                }
            }
        }

        private IEnumerable<ReportMaterialModel> Page(IEnumerable<ReportMaterialModel> entities, Paging paging)
        {
            if (paging.Take > 0)
            {
                entities = entities.Skip(paging.Skip).Take(paging.Take);
            }

            return entities;
        }
    }
}
