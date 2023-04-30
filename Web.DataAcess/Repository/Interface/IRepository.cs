using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Web.DataAccess.Repository.Interface
{
    public interface IRepository<T> where T : class
    {
        T Get(Expression<Func<T, bool>> filter, string? includeProperties = null);
        void add(T entity);
        void remove(T entity);
        IEnumerable<T> GetAll(string? includeProperties = null);
        void removeRange(IEnumerable<T> entity);
    }
}
