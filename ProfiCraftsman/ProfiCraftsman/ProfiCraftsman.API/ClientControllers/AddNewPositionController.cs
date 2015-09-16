using System.Linq;
using System.Web.Http;
using System.Web.Security;
using ProfiCraftsman.API.Models;
using ProfiCraftsman.Contracts.Managers;
using CoreBase;
using CoreBase.Models;
using System;
using System.Collections.Generic;
using ProfiCraftsman.Contracts.Enums;
using System.Linq;
using ProfiCraftsman.Contracts.Entities;
using System.Net.Mail;
using System.Net;
using ProfiCraftsman.API.Config;
using System.IO;
using System.Web;
using ProfiCraftsman.API.Controllers;

namespace ProfiCraftsman.API.ClientControllers
{
    public class AddNewPositionController : ApiController
	{
	    private readonly ITermsManager termManager;
        private readonly IProductsManager productManager;
        private readonly IPositionsManager positionsManager;
        private readonly IUserManager userManager;

        public AddNewPositionController(ITermsManager termManager, IProductsManager productManager, 
            IPositionsManager positionsManager, IUserManager userManager)
	    {
	        this.termManager = termManager;
	        this.productManager = productManager;
	        this.positionsManager = positionsManager;
            this.userManager = userManager;
        }

	    public IHttpActionResult Post([FromBody]AddNewPositionModel model)
		{
            var term = termManager.GetById(model.termId);
            ClientTermViewModel result = null;

            var product = productManager.GetById(model.productId);
            var user = userManager.GetByLogin(model.Login);

            if (user != null && user.Token == model.Token &&
                product != null && term != null)
            {
                var newPosition = new Positions()
                {
                    Amount = 1, //TODO
                    Description = product.Name,
                    ProductId = product.Id,
                    Price = product.Price,
                    OrderId = term.OrderId,
                };

                positionsManager.AddEntity(newPosition);
                

                var newTermPosition = new TermPositions()
                {
                    TermId = term.Id,
                    Amount = 1, //TODO
                    Positions = newPosition,
                    TermPositionMaterialRsps = new List<TermPositionMaterialRsp>()
                };

                term.TermPositions.Add(newTermPosition);


                //add linked material to position
                foreach (var material in product.ProductMaterialRsps.Where(o => !o.DeleteDate.HasValue))
                {
                    newTermPosition.TermPositionMaterialRsps.Add(new TermPositionMaterialRsp()
                    {
                        Amount = material.Amount,
                        MaterialId = material.MaterialId,
                        TermPositions = newTermPosition 
                    });
                }

                positionsManager.SaveChanges();



                if (term != null)
                {
                    result = TermViewModelHelper.ToModel(term, true, false);
                }

                return Ok(result);
            }

            return BadRequest();
		}
    }
}