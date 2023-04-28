using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.DataAccess.Data;

namespace Web.DataAccess.Repository
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly ApplicationDbContext _db;
		public IBrandRepository Brand { get; }

		public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
			Brand = new BrandRepository(_db); //  setting the value of the "Brand" property to a new
											  //  instance of the "BrandRepository" class, we can now use the methods and
											  //  properties defined in the "IBrandRepository" interface
		}
		public void update()
		{
			_db.SaveChanges();
		}
	}
}
