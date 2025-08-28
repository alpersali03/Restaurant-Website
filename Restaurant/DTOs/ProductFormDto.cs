using Restaurant.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.DTOs
{
    public class ProductFormDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public bool IsAvailable { get; set; }
        public int CategoryId { get; set; }

        public List<CategoryFormDto> Categories { get; set; } = new List<CategoryFormDto>();

    }
}
