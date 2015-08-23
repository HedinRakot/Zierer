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
                result = new ClientTermViewModel()
                {
                    Id = term.Id,
                    FromDate = String.Format("{0}", term.Date.ToString("HH:mm")),
                    ToDate = String.Format("{0}", term.Date.AddMinutes(term.Duration).ToString("HH:mm")),
                    Address = String.Format("{0} {1} {2}", term.Orders.Street, term.Orders.Zip, term.Orders.City),
                    Status = term.Status,
                };
            }

            return Ok(result);
		}	
	}
}