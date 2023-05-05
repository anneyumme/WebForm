using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Models;

namespace Web.DataAccess.Repository.Interface
{
    public interface IOrderDetailRepository : IRepository<OrderDetail>
    {
        void update(OrderDetail orderDetail);
        void save();
    }
}
