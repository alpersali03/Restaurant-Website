using Microsoft.AspNetCore.Identity;
using Restaurant.Data.Models;

namespace Restaurant.DTOs
{
    public class OrderFormDto
    {
        public int Id { get; set; }

        public int Number { get; set; }

        public decimal TotalAmount { get; set; }

        public OrderStatus Status { get; set; }

        public DateTime OrderTime { get; set; }

        public string IdentityUserId { get; set; }
        public IdentityUser IdentityUser { get; set; }


        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
