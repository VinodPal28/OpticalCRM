using OpticalCRM.EntityFramework.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OpticalCRM.EntityFramework.DomainContext
{
    public abstract class DomainContextBase : DbContext, IDomainContext
    {
      
        protected DomainContextBase(string connectionString) : base(connectionString)
        {

        }

        public void Add<T>(T entity) where T : class
        {
            Set<T>().Add(entity);
        }

        public void AddMany<T>(IEnumerable<T> entities) where T : class
        {
            foreach (var entity in entities)
            {
                Add(entity);
            }
        }

        public void AddOrUpdate<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        public void Delete<T>(T item) where T : class
        {
            Set<T>().Remove(item);
        }

        public void Delete<T>(int id) where T : class
        {
            throw new NotImplementedException();
        }

        public void DeleteMany<T>(ICollection<T> items) where T : class
        {
            throw new NotImplementedException();
        }

        public void Update<T>(T entity) where T : class
        {
            Set<T>().Attach(entity);
            Entry(entity).State = EntityState.Modified;
        }
     

        //public DbSet<Login> logins { get; set; }


        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        //}
    }
}
