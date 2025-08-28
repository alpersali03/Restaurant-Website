using Restaurant.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.DTOs
{
	public class ReviewFormDto
	{
		public int Id { get; set; }

		public string CustomerName { get; set; }
		public int Rating { get; set; }
		
		public string Comment { get; set; }
		public DateTime CreatedAt {get; set;}
        public int ProductId { get; set; }          
        public List<Product> Products { get; set; }    
    }
}
