using System.Linq;
using System.Web.Http;
using System.Web.Security;
using ProfiCraftsman.API.Models;
using ProfiCraftsman.Contracts.Managers;
using CoreBase;
using CoreBase.Models;
using System;

namespace ProfiCraftsman.API.Controllers
{
	public class LoginController : ApiController
	{
	    private readonly IUserManager _userManager;

	    public LoginController(IUserManager userManager)
	    {
	        this._userManager = userManager;
	    }

	    public IHttpActionResult Post([FromBody]LoginModel loginModel)
		{
			if (ModelState.IsValid)
			{
                var user = _userManager.GetByLogin(loginModel.Login);
				if (user != null && user.Password == StringHelper.GetMD5Hash(loginModel.Password) &&
                    user.Key == StringHelper.GetMD5Hash(String.Format("{0}_{1}", loginModel.Login, loginModel.Password)))
				{
					FormsAuthentication.SetAuthCookie(loginModel.Login, loginModel.RememberMe);
					return Ok(new LoggedUserModel
					{
						IsAuthenticated = true,
						Login = user.Login,
						Name = user.Name,
						//Permissions = user.Role.Permissions.ToDictionary(o => o.SystemName, o => true)
					});
				}

				ModelState.AddModelError("login", "invalid");
			}
			
			return BadRequest(ModelState);
		}

		public IHttpActionResult Patch([FromBody]LoggedUserModel model)
		{
			return Ok(model);			
		}		
	}
}