
using System.ComponentModel.DataAnnotations;

namespace MyShop.Entites.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Display(Name = "Created At")]
        public DateTime CreatedAdd { get; set; } = DateTime.Now;
    }
}
