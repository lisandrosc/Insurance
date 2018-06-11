using Insurance.Mocky;
using Insurance.Service;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace Insurance.Api
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            container.RegisterType<IClientService, ClientService>();
            container.RegisterType<IPolicyService, PolicyService>();
            container.RegisterType<IMockyService, MockyService>();


            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}