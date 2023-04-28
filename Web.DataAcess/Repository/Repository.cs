using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Web.DataAccess.Data;

namespace Web.DataAccess.Repository
{
	public class Repository<T> : IRepository<T> where T : class
	{
		private readonly ApplicationDbContext _db; //Depencies injection
		private readonly DbSet<T> dbSet;  // dbset methood reprsent table in database 
        public Repository(ApplicationDbContext db)

        {
            _db = db;
			dbSet=db.Set<T>();   // Set table specific for dbSet 
        }
        public void add(T entity)
		{
			dbSet.Add(entity);
		}

		public T Get(Expression<Func<T, bool>> filter)
		{
			IQueryable<T> query = dbSet;  //Query  represents a query that can be executed in database 
			query = query.Where(filter);
			return query.FirstOrDefault();
			

		}

		public IEnumerable<T> GetAll()
		{
			IQueryable<T> query = dbSet;
			return query.ToList();
		}

		public void remove(T entity)
		{
			dbSet.Remove(entity);
		}

		public void removeRange(IEnumerable<T> entity)
		{
			dbSet.RemoveRange(entity);
		}
	}
}
