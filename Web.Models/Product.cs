using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Web.Models
{
	public class Product
	{
		[Required]
		[Key] // Primary Key
		public int id { get; set; }
		[MaxLength(255)]
		[Display(Name = "Model")]
		public string model { get; set; }
		[Display(Name = "Description")]
		public string description { get; set; }
		[Display(Name = "Price")]
		[Range(0, 1000000)]
		[Required]
		public double price { get; set; }
		[Display(Name = "Phone Name")]
		public string name { get; set; }
		[Display(Name = "Brand Name")]
		[Required]
		public int brandId { get; set; }
		[ForeignKey("brandId")]
		[ValidateNever]
		public Brand brand { get; set; }
		[ValidateNever]
		[Display(Name = "Image File Upload")]
		[Required]
		public string imageUrl { get; set; }
		[Required]
		[Display(Name = "Year of production")]
		public double year { get; set; }
	}
}
