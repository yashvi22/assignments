using HotelManagement.BAL;
using HotelManagement.BAL.Helper;
using HotelManagement.BAL.Interfaces;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace HotelManagement
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IHotelManager, HotelManager>();
            container.RegisterType<IRoomManager, RoomManager>();
            container.RegisterType<IBookingManager, BookingManager>();

            container.AddNewExtension<UnityHelperClass>();
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}