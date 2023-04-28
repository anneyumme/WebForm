using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.DataAccess.Data;
using Web.Models;

namespace Web.DataAccess.Repository
{
	public class BrandRepository : Repository<Brand>, IBrandRepository
	{
		private readonly ApplicationDbContext _db;
        public BrandRepository( ApplicationDbContext db) : base(db) 
        {
            _db = db;
        }
        public void save()
		{
			_db.SaveChanges();
		}
		public void update(Brand obj)
		{
			_db.Brands.Update(obj);
		}
	}

}
