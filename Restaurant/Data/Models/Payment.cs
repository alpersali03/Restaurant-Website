using System.ComponentModel.DataAnnotations;

namespace Restaurant.Data.Models
{
    public class Payment
    {
        [Key]
        public int Id { get; set; }
        public DateTime PaidAt { get; set; }
        public decimal Amount { get; set; }
        public PaymentMethod Method { get; set; } // Enum: Cash, CreditCard, Online

        public int OrderId { get; set; }
        public Order Order { get; set; }
    }

}
