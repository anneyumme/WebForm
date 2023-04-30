using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Web.DataAccess.Data;
using Web.DataAccess.Repository.Interface;

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
			_db.Products.Include(u => u.brand).Include(u=>u.brandId);

		}
		public void add(T entity)
		{
			dbSet.Add(entity);
		}

		public T Get(Expression<Func<T, bool>> filter, string? includeProperties = null)
		{
			IQueryable<T> query = dbSet;  //Query  represents a query that can be executed in database 
			query = query.Where(filter);
			if (includeProperties != null)
			{
				foreach (var property in includeProperties.
					Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
				{
					query = query.Include(property);
				}
			}
			return query.FirstOrDefault();
			
		}

		public IEnumerable<T> GetAll(string? includeProperties = null)
		{
			IQueryable<T> query = dbSet;
			if(includeProperties != null)
			{
				foreach(var property in includeProperties.
					Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries)) 
				{
					query= query.Include(property);
				}
			}
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
