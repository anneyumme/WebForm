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
    public class OrderDetailRepository : Repository<OrderDetail>, IOrderDetailRepository
	{
		private readonly ApplicationDbContext _db;
        public OrderDetailRepository( ApplicationDbContext db) : base(db) 
        {
            _db = db;
        }
        public void save()
		{
			_db.SaveChanges();
		}
		public void update(OrderDetail obj)
		{
			_db.OrderDetails.Update(obj);
		}
	}

}
