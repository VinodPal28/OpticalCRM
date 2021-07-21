using OpticalCRM.Auth.CustomeFilter;
using OpticalCRM.Data.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace OpticalCRM.WebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {           
            GlobalConfiguration.Configure(WebApiConfig.Register);
            UnityConfig.RegisterComponents();
           // GlobalConfiguration.Configuration.Filters.Add(new CustomHeaderFilter());
        }
    }
}
