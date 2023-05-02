using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Models;

namespace Web.DataAccess.ViewModel
{
	public class ShoppingCartViewModel
	{
		public IEnumerable<ShoppingCart> ListCart { get; set; }
		public double TotalPrice { get; set; }	
	}
}
