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
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
    
    private readonly ApplicationDbContext _db;
        public OrderRepository( ApplicationDbContext db) : base(db) 
        {
            _db = db;
        }
        public void save()
		{
			_db.SaveChanges();
		}
		public void update(Order obj)
		{
			_db.Orders.Update(obj);
		}

		public void UpdateStatus(int id, string orderStatus, string? paymentStatus = null)
		{
			var	orderFromDb = _db.Orders.FirstOrDefault(o => o.Id == id);
			if (orderFromDb != null)
			{
				orderFromDb.orderStatus = orderStatus;
				if (paymentStatus != null)
				{
					orderFromDb.PaymentStatus = paymentStatus;
				}
			}
		}

		public void UpdateStripeId(int id, string sessionId, string paymentIntentId )
		{
			var orderFromDb = _db.Orders.FirstOrDefault(o => o.Id == id);
			if (sessionId != null)
			{
				orderFromDb.SessionId= sessionId;
			}
			if (paymentIntentId != null)
			{
				orderFromDb.PaymentItentId = paymentIntentId;
				orderFromDb.PaymentDate= DateTime.Now;
			}
		}
	}

}
