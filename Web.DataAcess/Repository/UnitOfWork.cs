using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.DataAccess.Data;
using Web.DataAccess.Repository.Interface;
using Web.Models;

namespace Web.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
	{
		private readonly ApplicationDbContext _db;
		public IBrandRepository Brand { get; }
		public IProductRepository Product { get; }
		public IShoppingCartRepository ShoppingCart { get; }
		public IUserApplication userApplication { get; }

		public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
			userApplication= new UserApplicationRepository(_db);
			Brand = new BrandRepository(_db);               //  setting the value of the "Brand" property to a new
			Product = new ProductRepository(_db);
			ShoppingCart = new ShoppingCartRepository(_db); //  instance of the "BrandRepository" class, we can now use the methods and
											                //  properties defined in the "IBrandRepository" interface
		}
		public void update()
		{
			_db.SaveChanges();
		}
	}
}
