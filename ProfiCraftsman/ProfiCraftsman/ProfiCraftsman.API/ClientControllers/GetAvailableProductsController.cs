﻿using System.Linq;
using System.Web.Http;
using System.Web.Security;
using ProfiCraftsman.API.Models;
using ProfiCraftsman.Contracts.Managers;
using CoreBase;
using CoreBase.Models;
using System;
using System.Collections.Generic;
using System.Linq.Dynamic;

namespace ProfiCraftsman.API.ClientControllers
{
    public class GetAvailableProductsController : ApiController
	{
	    private readonly IUserManager userManager;
	    private readonly IProductsManager productManager;

        public GetAvailableProductsController(IUserManager userManager, IProductsManager productManager)
	    {
	        this.userManager = userManager;
	        this.productManager = productManager;
        }

        public IHttpActionResult Post([FromBody]SearchModel model)
        {
            var result = new List<ProductViewModel>();

            var products = productManager.GetEntities();
            if (model != null && !String.IsNullOrEmpty(model.searchWord))
            {
                products = productManager.GetEntities().AsQueryable().
                    Where("Name.Contains(@0) || Number.Contains(@0)", model.searchWord).ToList();
            }

            result = products.ToList().Select(product => new ProductViewModel()
            {
                Id = product.Id,
                Name = product.Name,
                Number = product.Number,
            }).OrderBy(o => o.Name).ToList();

            return Ok(result);
        }
	}
}