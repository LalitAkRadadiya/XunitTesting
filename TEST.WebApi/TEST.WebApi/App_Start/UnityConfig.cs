using System.Web.Http;
using TEST.BAL;
using TEST.BAL.Helper;
using TEST.BAL.Interface;
using Unity;
using Unity.WebApi;

namespace TEST.WebApi
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IPassengerManger, PassengerManger>();
            container.AddNewExtension<UnityRepositoryHelper>();
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}