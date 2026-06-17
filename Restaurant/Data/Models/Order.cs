using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Data.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public int Number { get; set; }
        public decimal TotalAmount { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime OrderTime { get; set; }
        public string IdentityUserId { get; set; } = string.Empty;
        public IdentityUser? IdentityUser { get; set; }
        public int? CouponId { get; set; }
        public Coupon? Coupon { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
