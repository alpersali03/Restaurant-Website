using System.ComponentModel.DataAnnotations;

namespace Restaurant.Data.Models
{
    public class Coupon
    {
        [Key]
        public int Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public PercentageRate Percentage { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
