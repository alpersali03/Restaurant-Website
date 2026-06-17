using System.ComponentModel.DataAnnotations;

namespace Restaurant.DTOs
{
    public class CheckoutDto
    {
        public int OrderId { get; set; }
        public decimal OrderTotal { get; set; }

        [Required]
        public string FullName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Address { get; set; } = string.Empty;

        public string CouponCode { get; set; } = string.Empty;

        public List<CheckoutItemDto> Items { get; set; } = new();
    }

    public class CheckoutItemDto
    {
        public int OrderItemId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
