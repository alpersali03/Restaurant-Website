using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurant.Data.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        public string IconUrl { get; set; }

        // Navigation: one category has many products
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }

}
