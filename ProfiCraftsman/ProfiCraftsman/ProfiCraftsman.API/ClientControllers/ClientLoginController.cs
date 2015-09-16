using System.Linq;
using System.Web.Http;
using System.Web.Security;
using ProfiCraftsman.API.Models;
using ProfiCraftsman.Contracts.Managers;
using CoreBase;
using CoreBase.Models;
using System;

namespace ProfiCraftsman.API.ClientControllers
{
	public class ClientLoginController : ApiController
	{
	    private readonly IUserManager userManager;

	    public ClientLoginController(IUserManager userManager)
	    {
	        this.userManager = userManager;
	    }

	    public IHttpActionResult Post([FromBody]LoginModel loginModel)
		{
			if (ModelState.IsValid)
			{
                var user = userManager.GetByLogin(loginModel.Login);
				if (user != null && user.Password == StringHelper.GetMD5Hash(loginModel.Password))
				{
                    if (user.Employees != null)
                    {
                        user.Token = Guid.NewGuid().ToString();
                        userManager.SaveChanges();

                        return Ok(new LoggedUserModel
                        {
                            Token = user.Token,
                            IsAuthenticated = true,
                            Login = user.Login,
                            Name = String.Format("{0} {1}", user.Employees.Name, user.Employees.FirstName),
                        });
                    }
                    else
                    {
                        ModelState.AddModelError("login", "employeeNotSet");
                    }
				}

				ModelState.AddModelError("login", "loginWrong");
			}
			
			return BadRequest(ModelState);
		}	
	}
}