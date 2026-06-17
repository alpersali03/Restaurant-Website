using System.ComponentModel.DataAnnotations;

namespace Restaurant.Data.Models
{
    public class Review
    {
        [Key]
        public int Id { get; set; }

        [StringLength(100)]
        public string CustomerName { get; set; } = string.Empty;

        public int Rating { get; set; }

        [StringLength(200)]
        public string Comment { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; }

        public int ProductId { get; set; }
        public Product? Product { get; set; }
    }
}
