using Restaurant.Data.Models;
namespace Restaurant.DTOs
{
    public class CouponFormDto
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public decimal Percentage { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
