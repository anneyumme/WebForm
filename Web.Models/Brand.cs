using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class Brand
    {
        [Key] // Primary Key
        public int id { get; set; }
        [MaxLength(30)]
        [Display(Name = "Brand Name")]
        public string name { get; set; }
        [Display(Name = "Brand Description")]
        public string description { get; set; }
    }
}
