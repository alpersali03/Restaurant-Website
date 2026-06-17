using Restaurant.Data.Models;

namespace Restaurant.DTOs
{
    public class ReservationFormDto
    {
        public int Id { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public DateTime ReservationDate { get; set; }
        public int GuestCount { get; set; }
        public string Notes { get; set; } = string.Empty;
        public ReservationStatus Status { get; set; }
    }
}
