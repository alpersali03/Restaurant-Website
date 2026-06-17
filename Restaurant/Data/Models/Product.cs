using System.ComponentModel.DataAnnotations;

namespace Restaurant.Data.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [StringLength(300)]
        public string Description { get; set; } = string.Empty;

        public decimal Price { get; set; }

        [Required]
        public string ImageUrl { get; set; } = string.Empty;

        public bool IsAvailable { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        public ICollection<OrderItem> Orders { get; set; } = new List<OrderItem>();
    }
}
