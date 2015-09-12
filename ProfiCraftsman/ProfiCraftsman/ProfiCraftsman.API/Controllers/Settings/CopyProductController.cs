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

namespace ProfiCraftsman.API.Controllers
{

    /// <summary>
    ///     Controller for copy Products
    /// </summary>
    [AuthorizeByPermissions(PermissionTypes = new[] { Permissions.Products })]
    public partial class CopyProductController : ApiController
    {
        private readonly IProductsManager manager;

        public CopyProductController(IProductsManager manager)
        {
            this.manager = manager;
        }

        public IHttpActionResult Put(ProductsModel model)
        {
            var product = manager.GetById(model.Id);

            var newProduct = new Products()
            {
                Comment = product.Comment,
                ProductTypeId = product.ProductTypeId,
                Price = product.Price,
                ProceedsAccountId = product.ProceedsAccountId,
                Number = String.Empty,
                ProductMaterialRsps = new List<ProductMaterialRsp>(),
                CreateDate = DateTime.Now,
                ChangeDate = DateTime.Now,
            };
            
            manager.AddEntity(newProduct);

            foreach(var material in product.ProductMaterialRsps.Where(o => !o.DeleteDate.HasValue).ToList())
            {
                var newPosition = new ProductMaterialRsp()
                {
                    Amount = material.Amount,
                    MaterialId = material.MaterialId,
                    Products = newProduct
                };

                //positionManager.AddEntity(newPosition);
                newProduct.ProductMaterialRsps.Add(newPosition);
            }

            manager.SaveChanges();

            return Ok(new { id = newProduct.Id });
        }
    }
}
