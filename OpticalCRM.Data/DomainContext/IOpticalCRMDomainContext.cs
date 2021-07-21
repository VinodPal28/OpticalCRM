using OpticalCRM.EntityFramework.DomainContext;
using OpticalCRM.EntityFramework.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OpticalCRM.Data.DomainContext
{
    public interface IOpticalCRMDomainContext : IDomainContext
    {
        IQueryable<Login> Logins { get; }
        IQueryable<OpticalCRMUsers> opticalCRMUsers { get; }
        IQueryable<userMaster> userMasters { get; set; }
        IQueryable<userAuthentication> userAuthentications { get; }
        IQueryable<frame> frames { get; set; }

        IQueryable<log> logs { get; set; }

        int SaveChanges();       

    }
}
