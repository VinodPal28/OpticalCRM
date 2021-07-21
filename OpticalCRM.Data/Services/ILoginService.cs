using OpticalCRM.EntityFramework.Entity;
using OpticalCRM.Resources.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpticalCRM.Data.Services
{
    public interface ILoginService
    {
        List<userMasterResource> getCustomerDetails(string customerId);

        List<userAuthenticationResource> ValidateUser(string customerId, string username, string password);

        Boolean isValidCustomer(string customerId);
    }
}
