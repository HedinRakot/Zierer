using ProfiCraftsman.API.Models;
using ProfiCraftsman.API.Security;
using ProfiCraftsman.Contracts.Enums;
using ProfiCraftsman.Contracts.Managers;
using ProfiCraftsman.Contracts.Services;
using CoreBase;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Linq;

namespace ProfiCraftsman.API.Controllers
{
    public class ProductSearchModel
    {
        public int ProductTypeId { get; set; }
        public string Name { get; set; }
        public string StartDateStr { get; set; }
        public string EndDateStr { get; set; }
        public IEnumerable<int> Equipments { get; set; }
        public bool SearchFreeProduct { get; set; }

        public DateTime StartDate
        {
            get
            {
                var result = DateTime.Now;
                DateTime.TryParse(StartDateStr, out result);
                return result;
            }
        }

        public DateTime EndDate
        {
            get
            {
                var result = DateTime.Now;
                DateTime.TryParse(EndDateStr, out result);
                return result;
            }
        }
    }

    public class ProductViewModel
    {
        public string title { get; set; }
        public string url { get; set; }
        public string start { get; set; }
        public string end { get; set; }
    }

    /// <summary>
    ///     Controller for Disposition
    /// </summary>
    [AuthorizeByPermissions(PermissionTypes = new[] { Permissions.Orders })]
    public partial class ShowProductController : ApiController
    {
        private readonly IProductsManager manager;
        private readonly IProductTypesManager productTypesManager;
        private readonly IUniqueNumberProvider numberProvider;

        public ShowProductController(IProductsManager manager, IProductTypesManager productTypesManager, IUniqueNumberProvider numberProvider)
        {
            this.manager = manager;
            this.productTypesManager = productTypesManager;
            this.numberProvider = numberProvider;
        }

        public IHttpActionResult Post(ProductSearchModel model)
        {
            var result = new List<ProductViewModel>();

            if (!String.IsNullOrEmpty(model.StartDateStr) && !String.IsNullOrEmpty(model.EndDateStr))
            {
                if (model.SearchFreeProduct)
                {
                    var positionsQuery = manager.GetActualPositions(model.StartDate, model.EndDate).
                           Where(r => model.ProductTypeId == 0 || r.Products.ProductTypeId == model.ProductTypeId).
                           Where(r => String.IsNullOrEmpty(model.Name) || r.Products.Number.ToLower().Contains(model.Name.ToLower()));

                    var productTypeIds = productTypesManager.GetEntities(o => o.DispositionRelevant && !o.DeleteDate.HasValue).Select(o => o.Id).ToList();

                    //todo delete positionsQuery = positionsQuery.Where(o => productTypeIds.Contains(o.Products.ProductTypeId));

                    if (model.Equipments != null && model.Equipments.Count() != 0)
                    {
                        positionsQuery = positionsQuery.ToList()
                            .Where(r => model.Equipments.All(o => r.Products.ProductMaterialRsps.Select(t => t.MaterialId).Contains(o))).AsQueryable();
                    }

                    var positions = positionsQuery.ToList();

                    //process rented Products in case if they are available at some days
                    foreach (var product in positions.Select(o => o.Products).Distinct())
                    {
                        DateTime? startDate = null;
                        DateTime? endDate = null;
                        for (var date = model.StartDate; date <= model.EndDate; date = date.AddDays(1))
                        {
                            if (positions.Where(o => o.ProductId == product.Id).All(p => p.FromDate > date || p.ToDate < date))
                            {
                                if (startDate.HasValue)
                                {
                                    endDate = date;
                                }
                                else
                                {
                                    startDate = date;
                                    endDate = date;
                                }
                            }
                            else if (startDate.HasValue)
                            {
                                result.Add(new ProductViewModel()
                                {
                                    start = startDate.Value.ToString("yyyy-MM-dd"),
                                    end = endDate.Value.AddDays(1).ToString("yyyy-MM-dd"), //Add 1 days because calender end date is not included
                                    url = String.Empty,
                                    title = String.Format("{0} {1}", product.Number, product.ProductTypes.Name)
                                });

                                startDate = null;
                                endDate = null;
                            }
                        }
                        
                        if (startDate.HasValue)
                        {
                            result.Add(new ProductViewModel()
                            {
                                start = startDate.Value.ToString("yyyy-MM-dd"),
                                end = endDate.Value.AddDays(1).ToString("yyyy-MM-dd"), //Add 1 days because calender end date is not included
                                url = String.Empty,
                                title = String.Format("{0} {1}", product.Number, product.ProductTypes.Name)
                            });
                        }
                    }

                    AddFreeProducts(model, result, positions, productTypeIds);
                }
                else
                {
                    GetRentProducts(model, result);
                }
            }

            return Ok(result);
        }

        private void AddFreeProducts(ProductSearchModel model, List<ProductViewModel> result, List<Contracts.Entities.Positions> positions,
            List<int> productTypeIds)
        {
            var ids = positions.Select(o => o.ProductId.Value).Distinct();
            var freeProducts = manager.GetEntities(o => !ids.Contains(o.Id) &&
                (model.ProductTypeId == 0 || o.ProductTypeId == model.ProductTypeId) &&
                (String.IsNullOrEmpty(model.Name) || o.Number.ToLower().Contains(model.Name.ToLower())));

            freeProducts = freeProducts.Where(o => o.ProductTypeId.HasValue && productTypeIds.Contains(o.ProductTypeId.Value));

            if (model.Equipments != null && model.Equipments.Count() != 0)
            {
                freeProducts = freeProducts.ToList()
                    .Where(r => model.Equipments.All(o => r.ProductMaterialRsps.Select(t => t.MaterialId).Contains(o)));
            }

            foreach (var product in freeProducts.ToList())
            {
                result.Add(new ProductViewModel()
                {
                    start = model.StartDate.ToString("yyyy-MM-dd"),
                    end = model.EndDate.AddDays(1).ToString("yyyy-MM-dd"), //Add 1 days because calender end date is not included
                    url = String.Empty,
                    title = String.Format("{0} {1}", product.Number, product.ProductTypes.Name)
                });
            }
        }

        private void GetRentProducts(ProductSearchModel model, List<ProductViewModel> result)
        {
            var positions = manager.GetRentPositions(model.StartDate, model.EndDate,
                model.ProductTypeId != 0 ? model.ProductTypeId : (int?)null, model.Name, model.Equipments);
            
            foreach (var position in positions)
            {
                result.Add(new ProductViewModel()
                {
                    start = position.FromDate.ToString("yyyy-MM-dd"),
                    end = position.ToDate.AddDays(1).ToString("yyyy-MM-dd"), //Add 1 days because calender end date is not included
                    url = String.Format("#Orders/{0}", position.OrderId),
                    title = String.Format("{0} {1} ({2})", position.Products.Number,
                        position.Products.ProductTypes.Name, position.Orders.OrderNumber)
                });
            }
        }
    }
}
