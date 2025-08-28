using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurant.Data.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(300)] 
        public string Description { get; set; }
        public decimal Price { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        public bool IsAvailable { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<OrderItem> Orders { get; set; } = new List<OrderItem>();
    }
}
