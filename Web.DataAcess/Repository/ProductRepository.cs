using Microsoft.EntityFrameworkCore;
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
	public class ProductRepository : Repository<Product>, IProductRepository
	{
		private readonly ApplicationDbContext _db;
		public ProductRepository(ApplicationDbContext db) : base(db)
		{
			_db = db;
		}
		public void update(Product product)
		{
			_db.Products.Update(product);
		}
		public void save()
		{
			_db.SaveChanges();
		}

	}
}
