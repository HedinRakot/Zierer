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
                var date = DateTime.Now.Date;
                if(model.termsForTommorow)
                {
                    date = date.AddDays(1);
                }

                var terms = termManager.GetEntities(o => 
                o.TermEmployees.Any(e => !e.DeleteDate.HasValue && e.EmployeeId == user.EmployeeId.Value) && o.Date.Date == date);
                result = terms.Select(term => TermViewModelHelper.ToModel(term, false, false)).OrderBy(o => o.FromDate).ToList();
            }

            return Ok(result);
		}	
	}
}