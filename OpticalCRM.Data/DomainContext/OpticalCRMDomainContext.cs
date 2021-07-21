using OpticalCRM.EntityFramework.DomainContext;
using OpticalCRM.EntityFramework.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OpticalCRM.Data.DomainContext
{
    public class OpticalCRMDomainContext : DomainContextBase, IOpticalCRMDomainContext
    {

        #region properties

        public virtual DbSet<Login> Logins { get; set; }

        public virtual DbSet<OpticalCRMUsers> OpticalCRMUsers { get; set; }

        public virtual DbSet<userMaster> userMasters { get; set; }

        public virtual DbSet<userAuthentication> userAuthentications { get; set; }

        public virtual DbSet<frame> frames { get; set; }

        public virtual DbSet<log> logs { get; set; }

        #endregion

        #region Constructor
        static OpticalCRMDomainContext()
        {
            Database.SetInitializer(new NullDatabaseInitializer<OpticalCRMDomainContext>());
        }

        public OpticalCRMDomainContext() : base("opticalCRM")
        {

        }

        #endregion

        #region implementation of IOpticalCRMDomainContext

        IQueryable<Login> IOpticalCRMDomainContext.Logins
        {
            get { return Logins.AsQueryable(); }
           
        }

        IQueryable<OpticalCRMUsers> IOpticalCRMDomainContext.opticalCRMUsers
        {
            get { return OpticalCRMUsers.AsQueryable(); }

        }
        IQueryable<userMaster> IOpticalCRMDomainContext.userMasters
        {
            get { return userMasters.AsQueryable(); }

            set {}

        }

        IQueryable<userAuthentication> IOpticalCRMDomainContext.userAuthentications
        {
            get { return userAuthentications.AsQueryable(); }

        }

        IQueryable<frame> IOpticalCRMDomainContext.frames
        {
            get { return frames.AsQueryable(); }
            set { frames.AsQueryable(); }

        }

        IQueryable<log> IOpticalCRMDomainContext.logs
        {
            get { return logs.AsQueryable(); }
            set { logs.AsQueryable(); }

        }


        #endregion

        #region overrides of DbCOntext

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
            
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
      
        #endregion
    }
}
