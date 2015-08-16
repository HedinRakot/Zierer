using Microsoft.Practices.Unity;
using System.Web.Http;
using ProfiCraftsman.Configuration;
using Unity.WebApi;

namespace ProfiCraftsmanWeb
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            UnityConfiguration.ConfigureContainer(container);
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}