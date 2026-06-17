using System.ComponentModel.DataAnnotations;

namespace Restaurant.Data.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string IconUrl { get; set; } = string.Empty;

        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
