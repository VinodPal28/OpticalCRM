using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OpticalCRM.Resources.Resources
{
    public class customResponse
    {
        public string Token { get; set; }
        public HttpResponseMessage responseMsg { get; set; }

        public customResponse()
        {
            this.Token = "";
            this.responseMsg = new HttpResponseMessage() { StatusCode = System.Net.HttpStatusCode.Unauthorized };
        }
    }
}
