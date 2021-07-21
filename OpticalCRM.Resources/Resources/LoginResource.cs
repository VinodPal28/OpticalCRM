using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OpticalCRM.DependencyResolution.Resources
{
    public class LoginResource
    {      
        public string customerId { get; set; }
        public string username { get; set; }
        public string password { get; set; }                
    }
}
