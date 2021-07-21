using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OpticalCRM.EntityFramework.DomainContext
{
    public interface IDomainContext : IDisposable
    {
        void Add<T>(T entity) where T : class;

        void AddMany<T>(IEnumerable<T> entities) where T : class;

        void AddOrUpdate<T>(T entity) where T : class;

        void Update<T>(T entity) where T : class;

        void Delete<T>(int id) where T : class;

        void Delete<T>(T item) where T : class;

        void DeleteMany<T>(ICollection<T> items) where T : class;
       
    }
}
