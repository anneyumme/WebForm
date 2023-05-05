using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
		[Display(Name = "Street Address")]
		public string? StreetAdress { get; set; }
		public string? City { get; set; }
		public string? Province { get; set; }
        [NotMapped]
        [Display(Name= "Persimmon")]
        public string Role { get; set; }


	}
}
