using OpticalCRM.Data.DomainContext;
using OpticalCRM.Data.Services;
using OpticalCRM.Data.Services.Implementations;
using OpticalCRM.WebApi.ExceptionHandler.CustomHandler;
using OpticalCRM.WebApi.ExceptionHandler.logs;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace OpticalCRM.WebApi
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<ILoginService, LoginService>();
            container.RegisterType<IframeService, frameService>();
            container.RegisterType<IOpticalCRMDomainContext, OpticalCRMDomainContext>();
            //container.RegisterType<IErrorLogging, ErrorLogging>();
            //container.RegisterType<IUnhandledExceptionLogger, UnhandledExceptionLogger>();
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}