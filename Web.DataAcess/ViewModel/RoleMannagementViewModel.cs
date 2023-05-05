using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Models;

namespace Web.DataAccess.ViewModel
{
	public class RoleMannagementViewModel
	{
		public UserApplication UserApplication { get; set; }
		public IEnumerable<SelectListItem> RoleList { get; set; }

	}
}
