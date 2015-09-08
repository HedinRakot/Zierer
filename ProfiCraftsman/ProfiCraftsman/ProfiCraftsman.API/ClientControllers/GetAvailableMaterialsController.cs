using System.Linq;
using System.Web.Http;
using System.Web.Security;
using ProfiCraftsman.API.Models;
using ProfiCraftsman.Contracts.Managers;
using CoreBase;
using CoreBase.Models;
using System;
using System.Collections.Generic;
using ProfiCraftsman.Contracts.Entities;

namespace ProfiCraftsman.API.ClientControllers
{
    public class GetAvailableMaterialsController : ApiController
	{
	    private readonly IUserManager userManager;
	    private readonly IMaterialsManager materialManager;

        public GetAvailableMaterialsController(IUserManager userManager, IMaterialsManager materialManager)
	    {
	        this.userManager = userManager;
	        this.materialManager = materialManager;
        }

        public IHttpActionResult Post([FromBody]SearchModel model)
        {
            var result = new List<MaterialViewModel>();

            var materials = new List<Materials>();
            if (model != null && !String.IsNullOrEmpty(model.searchWord))
            {
                materials = materialManager.GetEntities().
                    Where(o => o.Number.ToLower().Contains(model.searchWord) || o.Name.ToLower().Contains(model.searchWord)).ToList();
            }

            result = materials.Select(material => new MaterialViewModel()
            {
                Id = material.Id,
                Name = material.Name,
                Number = material.Number,
            }).OrderBy(o => o.Name).ToList();

            return Ok(result);
        }
	}
}