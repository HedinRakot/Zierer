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
    public class ClientTermsController : ApiController
	{
	    private readonly IUserManager userManager;
	    private readonly ITermsManager termManager;

        public ClientTermsController(IUserManager userManager, ITermsManager termManager)
	    {
	        this.userManager = userManager;
	        this.termManager = termManager;
        }

	    public IHttpActionResult Post([FromBody]ClientTermSearchModel model)
		{
            var user = userManager.GetByLogin(model.userLogin);
            var result = new List<ClientTermViewModel>();

            if(user != null && user.EmployeeId.HasValue)
            {
                var terms = termManager.GetEntities(o => o.EmployeeId == user.EmployeeId.Value && o.Date.Date == DateTime.Now.Date);
                result = terms.Select(o => new ClientTermViewModel()
                {
                    Id = o.Id,
                    FromDate = String.Format("{0}", o.Date.ToString("HH:mm")),
                    ToDate = String.Format("{0}", o.Date.AddMinutes(o.Duration).ToString("HH:mm")),
                    Address = String.Format("{0} {1} {2}", o.Orders.Street, o.Orders.Zip, o.Orders.City),
                    Status = o.Status,
                }).OrderBy(o => o.FromDate).ToList();
            }

            return Ok(result);
		}	
	}
}