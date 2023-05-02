using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Models;

namespace Web.DataAccess.Repository.Interface
{
	public interface IShoppingCartRepository : IRepository<ShoppingCart>
	{
		void update(ShoppingCart shoppingCart );
		void save();
	}
}
