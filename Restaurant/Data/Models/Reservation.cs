using System.ComponentModel.DataAnnotations;

namespace Restaurant.Data.Models
{
    public class Reservation
    {
        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        public string CustomerName { get; set; }
        [StringLength(100)] 
        public string PhoneNumber { get; set; }
        public DateTime ReservationDate { get; set; }
        public int GuestCount { get; set; }
        [StringLength(300)]
        public string Notes { get; set; }
        public ReservationStatus Status { get; set; } // Pending, Confirmed, Cancelled
    }

}
