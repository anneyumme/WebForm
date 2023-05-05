using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string ApplicationUserId { get; set; }
        [ForeignKey(nameof(ApplicationUserId))]
        [ValidateNever]
        public UserApplication ApplicationUser { get; set; }
        public DateTime OrderCreate { get; set; }
        public DateTime ShippingDate { get; set; }

        public double OrderTotal { get; set; }
        public string? orderStatus { get; set; }

        public string? PaymentStatus { get; set;}
        public DateTime PaymentDate { get; set; }
        public DateTime PaymentDueDate { get; set; }
        public string ? PaymentItentId { get; set; }
        public string? SessionId { get; set; }
		[Display(Name = "Payment Type")]
        public string paymentType { get; set; }

        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string StreetAdress { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Province { get; set; }
        [Required]
        public string Name { get; set; }

    }
}
