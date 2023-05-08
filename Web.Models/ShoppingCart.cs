﻿using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Models
{
	public class ShoppingCart
	{
		//Each Shoppping Cart is like a cart of many products but only belongs to one user
		public int Id { get; set; }
		public int ProductId { get; set; }
		[Range(0, 1000, ErrorMessage ="Please enter a value between 1 and 1000")]
		public int Quantity { get; set; } //quantity each product
		public string ApplicationUserId { get; set; }

		[ValidateNever]
		[ForeignKey("ProductId")]
		public Product Product { get; set; }

		[ValidateNever]
		[ForeignKey("ApplicationUserId")]
		public UserApplication ApplicationUser { get; set; }
		[NotMapped]
		public double price { get; set; } //quantity each product
	}
}
