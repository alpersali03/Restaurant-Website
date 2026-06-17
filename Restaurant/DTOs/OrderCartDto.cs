using Restaurant.Data.Models;

namespace Restaurant.DTOs
{
    public class OrderCartDto
    {
        public int Id { get; set; }
        public Order? Order { get; set; }
        public string IdentityUserId { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int CheckoutId { get; set; }
        public Checkout? Checkout { get; set; }
    }
}
