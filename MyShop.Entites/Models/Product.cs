using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace MyShop.Entites.Models
{
    public class Product
    {
        [Required, Key]
        public int id { get; set; }

        [Required]
        public string name { get; set; }
        [Required]
        public string description { get; set; }
        [Required]
        [ValidateNever]
        [Display(Name = "Image Url")]
        public string img { get; set; }
        [Required]
        public decimal price { get; set; }

        [ValidateNever]
        [Display(Name = "Category")]
        public int categoryId { get; set; }

        [ValidateNever]
        public Category category { get; set; }

        public DateTime CreatedAdd { get; set; } = DateTime.Now;



    }
}
