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
                BoughtFrom = product.BoughtFrom,
                BoughtPrice = product.BoughtPrice,
                Color = product.Color,
                Comment = product.Comment,
                ProductTypeId = product.ProductTypeId,
                Height = product.Height,
                IsSold = false, //Product.IsSold,
                IsVirtual = product.IsVirtual,
                Length = product.Length,
                ManufactureDate = product.ManufactureDate,
                MinPrice = product.MinPrice,
                NewPrice = product.NewPrice,
                Price = product.Price,
                ProceedsAccount = product.ProceedsAccount,
                SellPrice = product.SellPrice,
                Width = product.Width,
                Number = String.Empty,
                ProductEquipmentRsps = new List<ProductEquipmentRsp>(),
                CreateDate = DateTime.Now,
                ChangeDate = DateTime.Now,
            };
            
            manager.AddEntity(newProduct);

            foreach(var equipment in product.ProductEquipmentRsps.Where(o => !o.DeleteDate.HasValue).ToList())
            {
                var newPosition = new ProductEquipmentRsp()
                {
                    Amount = equipment.Amount,
                    EquipmentId = equipment.EquipmentId,
                    Products = newProduct
                };

                //positionManager.AddEntity(newPosition);
                newProduct.ProductEquipmentRsps.Add(newPosition);
            }

            manager.SaveChanges();

            return Ok(new { id = newProduct.Id });
        }
    }
}
