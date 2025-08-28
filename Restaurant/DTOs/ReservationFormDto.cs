using Restaurant.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.DTOs
{
	public class ReservationFormDto
	{
		
		public int Id { get; set; }
		public string CustomerName { get; set; }
		public string PhoneNumber { get; set; }
		public DateTime ReservationDate { get; set; }
		public int GuestCount { get; set; }
		public string Notes { get; set; }
		public ReservationStatus Status { get; set; } // Pending, Confirmed, Cancelled
	}
}
