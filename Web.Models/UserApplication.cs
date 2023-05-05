using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Models
{
    public class UserApplication : IdentityUser
    {
        [Required]
        [Display(Name = "Full Name")]
        public string? FullName { get; set; }
        public string? AvatarUrl { get; set; }
		public string? StreetAdress { get; set; }
		public string? City { get; set; }
		public string? Province { get; set; }


	}
}
