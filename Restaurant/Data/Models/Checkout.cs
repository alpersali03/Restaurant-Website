using System.ComponentModel.DataAnnotations;

namespace Restaurant.Data.Models
{
    public class Checkout
    {
        public int Id { get; set; }

        [Required]
        public int OrderId { get; set; }
        public Order? Order { get; set; }

        [Required]
        public string FullName { get; set; } = string.Empty;

        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Address { get; set; } = string.Empty;

        public string CouponCode { get; set; } = string.Empty;
    }
}
