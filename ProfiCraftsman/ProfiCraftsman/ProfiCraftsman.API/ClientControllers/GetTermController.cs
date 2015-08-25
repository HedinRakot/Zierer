using System.Linq;
using System.Web.Http;
using System.Web.Security;
using ProfiCraftsman.API.Models;
using ProfiCraftsman.Contracts.Managers;
using CoreBase;
using CoreBase.Models;
using System;
using System.Collections.Generic;

namespace ProfiCraftsman.API.ClientControllers
{
    public class GetTermController : ApiController
	{
	    private readonly ITermsManager termManager;

        public GetTermController(ITermsManager termManager)
	    {
	        this.termManager = termManager;
        }

	    public IHttpActionResult Post([FromBody]GetTermModel model)
		{
            var term = termManager.GetById(model.termId);
            ClientTermViewModel result = null;

            if(term != null)
            {
                result = TermViewModelHelper.ToModel(term, model.withPositions, model.withMaterials);
            }

            return Ok(result);
		}	
	}
}