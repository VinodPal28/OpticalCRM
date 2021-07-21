using OpticalCRM.Auth.Token;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace OpticalCRM.Auth.CustomeFilter
{
    public class CustomHeaderFilter : ActionFilterAttribute
    {
        public override bool AllowMultiple { get { return false; } }
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            var User = System.Web.HttpContext.Current.User;
            var Token = TokenManager.GenerateToken(User.Identity.Name);
            actionExecutedContext.Response.Headers.Add("Token", Token);
        }

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var User = System.Web.HttpContext.Current.User;
            var Token = TokenManager.GenerateToken(User.Identity.Name);
            //actionExecutedContext.Response.Headers.Add("Token", Token);
            actionContext.Response.Headers.Add("Token", Token);
        }
    }
}
