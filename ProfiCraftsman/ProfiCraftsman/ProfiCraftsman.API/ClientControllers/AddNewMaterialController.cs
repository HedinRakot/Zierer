﻿using System.Linq;
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
    public class AddNewMaterialController : ApiController
	{
	    private readonly ITermsManager termManager;
        private readonly IMaterialsManager materialManager;
        private readonly IPositionsManager positionsManager;
        private readonly IUserManager userManager;

        public AddNewMaterialController(ITermsManager termManager, IMaterialsManager materialManager, 
            IPositionsManager positionsManager, IUserManager userManager)
	    {
	        this.termManager = termManager;
	        this.materialManager = materialManager;
	        this.positionsManager = positionsManager;
            this.userManager = userManager;
        }

	    public IHttpActionResult Post([FromBody]AddNewMaterialModel model)
		{
            var term = termManager.GetById(model.termId);
            ClientTermViewModel result = null;

            var material = materialManager.GetById(model.materialId);
            var user = userManager.GetByLogin(model.Login);

            if (user != null && user.Token == model.Token &&
                material != null && term != null)
            {
                var newPosition = new Positions()
                {
                    Amount = 1, //TODO
                    Description = material.Name,
                    MaterialId = material.Id,
                    Price = material.Price,
                    OrderId = term.OrderId,
                    IsMaterialPosition = true,
                    TermId = term.Id,
                    CreateDate = DateTime.Now,
                    ChangeDate = DateTime.Now,
                };

                positionsManager.AddEntity(newPosition);

                positionsManager.SaveChanges();

                if (term != null)
                {
                    result = TermViewModelHelper.ToModel(term, false, true);
                }

                return Ok(result);
            }

            return BadRequest();
		}
    }
}