using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurant.Data.Models
{
    public class Coupon
    {
        [Key]
        public int Id { get; set; }
        public string Code { get; set; }    
        public PercentageRate Percentage { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

    }

}
