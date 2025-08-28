using Restaurant.Data.Models;

namespace Restaurant.DTOs
{
    public class PaymentFormDto
    {
        public int Id { get; set; }
        public DateTime PaidAt { get; set; }
        public decimal Amount { get; set; }
        public PaymentMethod Method { get; set; } // Enum: Cash, CreditCard, Online

        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}
