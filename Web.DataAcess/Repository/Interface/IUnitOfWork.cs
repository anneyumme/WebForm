using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Models;

namespace Web.DataAccess.Repository.Interface
{
    public interface IUnitOfWork
    {
        IShoppingCartRepository ShoppingCart { get; }
        IBrandRepository Brand { get; }
        IProductRepository Product { get; }
		IUserApplication userApplication { get; }
        IOrderRepository Order { get; }
        IOrderDetailRepository OrderDetail { get; }

        void update();
    }
}
