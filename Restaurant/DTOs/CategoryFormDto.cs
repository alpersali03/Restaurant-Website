using Restaurant.Data.Models;

namespace Restaurant.DTOs
{
	public class CategoryFormDto
	{
		public int Id { get; set; }
		public string Name { get; set; }
		
		public string IconUrl { get; set; }

		public ICollection<Product> Products { get; set; } = new List<Product>();

	}
}
