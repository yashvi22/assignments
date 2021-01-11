using ProductMangementSystem.BAL;
using ProductMangementSystem.BAL.Helper;
using ProductMangementSystem.BAL.Interfaces;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace ProductManagementSystem
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            container.RegisterType<IUserManager, UserManager>();

            container.AddNewExtension<UnityHelperMethod>();
            
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}