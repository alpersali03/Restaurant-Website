using System.ComponentModel.DataAnnotations;

namespace Restaurant.Data.Models
{
    public class Checkout
    {
        public int Id { get; set; }

        [Required]
        public int OrderId { get; set; }
        public Order Order { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Address { get; set; }

        [Required, CreditCard]
        public string CardNumber { get; set; }

        [Required]
        public string ExpirationDate { get; set; }

        [Required]
        public string CVV { get; set; }
    }
}
