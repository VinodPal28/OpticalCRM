using OpticalCRM.Data.DomainContext;
using OpticalCRM.EntityFramework.Entity;
using OpticalCRM.Resources.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace OpticalCRM.Data.Services.Implementations
{
    public class LoginService : ILoginService
    {
        private readonly IOpticalCRMDomainContext _opticalCRMDomainContext;

        public LoginService(IOpticalCRMDomainContext opticalCRMDomainContext)
        {
            _opticalCRMDomainContext = opticalCRMDomainContext;
        }
        public List<userMasterResource> getCustomerDetails(string customerId)
        {
            var userDetails = _opticalCRMDomainContext.userMasters
                .Where(user => user.CustomerId == customerId)
                .Select(user => new userMasterResource
                {
                    CustomerId = user.CustomerId,
                    ShopName = user.ShopName,
                    LogoName = user.LogoName
                }).ToList();
            
            return userDetails;
        }

        public Boolean isValidCustomer(string customerId)
        {            
            var query = (from user in _opticalCRMDomainContext.userMasters
                         where user.CustomerId == customerId
                         select user).Any(); 
            return query;
        }

        public List<userAuthenticationResource> ValidateUser(string customerId, string username, string password)
        {
            var user = _opticalCRMDomainContext.userAuthentications
                .Where(x => x.customerId == customerId && x.username == username && x.password == password)
                .Select(x => new userAuthenticationResource
                {
                    customerId = x.customerId,
                    username = x.username,
                    
                }).ToList();
            return user;
        }
    }
}
