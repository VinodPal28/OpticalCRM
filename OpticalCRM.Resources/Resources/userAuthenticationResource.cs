using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OpticalCRM.Resources.Resources
{
    public class userAuthenticationResource
    {
        public string customerId { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public int status { get; set; }
        public int createBy { get; set; }
        public DateTime createDate { get; set; }
        public int updatedBy { get; set; }
        public DateTime updatedDate { get; set; }
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public HttpResponseMessage responseMsg { get; set; }
        public userAuthenticationResource()
        {
            this.Token = "";
            this.RefreshToken = "";
            this.responseMsg = new HttpResponseMessage() { StatusCode = System.Net.HttpStatusCode.Unauthorized };
        }
    }
}
