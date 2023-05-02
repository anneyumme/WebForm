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
    public class UserApplicationRepository : Repository<UserApplication>, IUserApplication
	{
		private readonly ApplicationDbContext _db;
        public UserApplicationRepository( ApplicationDbContext db) : base(db) 
        {
            _db = db;
        }
        public void save()
		{
			_db.SaveChanges();
		}
		public void update(UserApplication obj)
		{
			_db.UserApplications.Update(obj);
		}
	}

}
