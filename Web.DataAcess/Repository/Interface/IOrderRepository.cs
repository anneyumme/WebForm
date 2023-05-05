using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Models;

namespace Web.DataAccess.Repository.Interface
{
    public interface IOrderRepository : IRepository<Order>
    {
        void update(Order order);
        void save();
        void UpdateStatus(int id, string orderStatus, string? paymentStatus= null);
		void UpdateStripeId(int id, string sessionId, string paymentIntentId );

	}
}
