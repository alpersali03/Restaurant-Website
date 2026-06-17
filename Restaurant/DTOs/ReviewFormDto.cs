using Restaurant.Data.Models;

namespace Restaurant.DTOs
{
    public class ReviewFormDto
    {
        public int Id { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public int Rating { get; set; }
        public string Comment { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public List<Product> Products { get; set; } = new();
    }
}
