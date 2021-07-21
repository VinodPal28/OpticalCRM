using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using OpticalCRM.EntityFramework.DomainContext;
using OpticalCRM.EntityFramework.Entity;
using OpticalCRM.Data.DomainContext;
using OpticalCRM.Data.Services;
using OpticalCRM.Data.Services.Implementations;
using OpticalCRM.DependencyResolution.Resources;
using OpticalCRM.Auth.Token;
using OpticalCRM.Auth.Authentication;
using OpticalCRM.Resources.Resources;
using System.Text;
using System.Web;
using System.IO;

namespace OpticalCRM.WebApi.Controllers
{
    [RoutePrefix("api/Login")]
    public class LoginsController : ApiController
    {
        //private readonly IOpticalCRMDomainContext _opticalCRMDomainContext;
        private readonly ILoginService _loginService;


        public LoginsController(ILoginService loginService)
        {
            _loginService = loginService;
            //_opticalCRMDomainContext = opticalCRMDomainContext;
        }


        // GET: api/Logins
        //[HttpGet]
        //[CustomAuthenticationFilter]
        //[Route("getData", Name = "getData")]
        //public IQueryable<LoginResource> Getlogins()
        //{
        //    var result = (from logins in _opticalCRMDomainContext.Logins
        //                  select new LoginResource()
        //                  {
        //                      username = logins.UserName,

        //                  }).ToList<LoginResource>().AsQueryable();

        //    var res = _opticalCRMDomainContext.opticalCRMUsers.ToList();
        //    return result;
        //}

        //[HttpGet]
        //[Route("validLogin", Name = "validLogin")]
        //public HttpResponseMessage validLogin(string userName, string userPassword)
        //{
        //    if (userName == "admin" && userPassword == "admin")
        //    {
        //        return Request.CreateResponse(HttpStatusCode.OK, TokenManager.GenerateToken(userName));
        //    }
        //    else
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.BadGateway, "User name & password is invalid");
        //    }
        //}

        [HttpPost]
        [Route("authentication", Name = "authentication")]
        public HttpResponseMessage authentication(LoginResource model)
        {
            if (!string.IsNullOrEmpty(model.username) && !string.IsNullOrEmpty(model.password) && !string.IsNullOrEmpty(model.customerId))
            {
                userAuthenticationResource user = _loginService.ValidateUser(model.customerId, model.username, model.password).ToList().FirstOrDefault();
                if (user == null)
                {
                    return Request.CreateResponse(HttpStatusCode.Unauthorized);
                }
                else
                {
                    user.Token = TokenManager.GenerateToken(model.username);
                    user.RefreshToken = TokenManager.generateRefreshToken();
                    user.responseMsg.StatusCode = HttpStatusCode.OK;
                    return Request.CreateResponse(HttpStatusCode.OK, user, Configuration.Formatters.JsonFormatter);
                }
            }

            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        //[HttpGet]
        //[CustomAuthenticationFilter]
        //[Route("GetEmployee", Name = "GetEmployee")]
        //public HttpResponseMessage GetEmployee()
        //{
        //    return Request.CreateResponse(HttpStatusCode.OK, "Successfully valid");
        //}

        [HttpPost]
        [Route("getCustomerDetails", Name = "getCustomerDetails")]
        public HttpResponseMessage getCustomerDetails(LoginResource model)
        {
            if (!string.IsNullOrEmpty(model.customerId))
            {
                var user = _loginService.isValidCustomer(model.customerId);
                if (user)
                {                    
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.Unauthorized);
                }
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }
        
        [HttpPost]
        [Route("customerDetails", Name = "customerDetails")]
        public HttpResponseMessage customerDetails(LoginResource model)
        {
            if (!string.IsNullOrEmpty(model.customerId))
            {
                userMasterResource userMaster = _loginService.getCustomerDetails(model.customerId).ToList().FirstOrDefault();
                if (userMaster != null)
                {
                    if (userMaster.LogoName != "")
                    {
                        string host = HttpContext.Current.Request.Url.Authority;                       
                        //var path = System.Web.Hosting.HostingEnvironment.MapPath("~/Uploads/logoImage/" + userMaster.LogoName + "");
                        var path = "http://" + host + "/Uploads/logoImage/" + userMaster.LogoName + "";
                        userMaster.LogoPath = path;
                    }
                    userMaster.responseMsg.StatusCode = HttpStatusCode.OK;
                    return Request.CreateResponse(HttpStatusCode.OK, userMaster, Configuration.Formatters.JsonFormatter);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.Unauthorized);
                }
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

    }
}