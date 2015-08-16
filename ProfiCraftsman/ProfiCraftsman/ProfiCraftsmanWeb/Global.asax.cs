using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace ProfiCraftsmanWeb
{
    public class ProfiCraftsmanWebApplication : HttpApplication
    {
        protected void Application_Start()
        {
			AreaRegistration.RegisterAllAreas();
            UnityConfig.RegisterComponents();
			GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
