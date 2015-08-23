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
    public class ClientTermPositionsController : ApiController
	{
	    private readonly ITermsManager termManager;

        public ClientTermPositionsController(ITermsManager termManager)
	    {
	        this.termManager = termManager;
        }

	    public IHttpActionResult Post([FromBody]GetTermModel model)
		{
            var term = termManager.GetById(model.termId);
            var result = new List<ClientTermPositionViewModel>();

            if (term != null)
            {
                var positions = term.TermPositions.Where(o => o.Positions.ProductId.HasValue).ToList();
                for (int i = 0; i < positions.Count; i++)
                {
                    var position = positions[i];
                    result.Add(new ClientTermPositionViewModel()
                    {
                        Id = position.Id,
                        Number = (i + 1).ToString(),
                        Description = position.Positions.Products.Name,
                        PlannedAmount = position.Amount.ToString(),
                        TermId = position.TermId,
                    });
                }
            }

            return Ok(result);
		}	
	}
}