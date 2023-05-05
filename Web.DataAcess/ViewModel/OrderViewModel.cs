using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Models;

namespace Web.DataAccess.ViewModel
{
	public class OrderViewModel
	{
		public Order Order { get; set; }
		public IEnumerable<OrderDetail> OrderDetail { get; set; }
	}
}
