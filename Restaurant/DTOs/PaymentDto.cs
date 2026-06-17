using Restaurant.Data.Models;

namespace Restaurant.DTOs
{
    public class PaymentDto
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? CompletedAt { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; } = "usd";
        public string Provider { get; set; } = string.Empty;
        public string ProviderSessionId { get; set; } = string.Empty;
        public string? ProviderPaymentId { get; set; }
        public PaymentStatus Status { get; set; }
        public int OrderId { get; set; }
        public Order? Order { get; set; }
    }
}
