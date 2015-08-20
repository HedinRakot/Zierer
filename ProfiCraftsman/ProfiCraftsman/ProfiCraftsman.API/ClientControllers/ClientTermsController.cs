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
    public class ClientTermViewModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
    }

    public class ClientTermSearchModel
    {
        public string userLogin { get; set; }
    }


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
                    Description = String.Format("{0}    {1} {2} {3}", o.Date.ToString("dd.MM.yyyy HH:mm"),
                        o.Orders.Street, o.Orders.Zip, o.Orders.City)
                }).ToList();
            }

            return Ok(result);
		}	
	}
}