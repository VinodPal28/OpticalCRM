using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OpticalCRM.WebApi.Controllers
{
    public class HomeController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage customerValidator()
        {
            return null;
        }
    }
}
