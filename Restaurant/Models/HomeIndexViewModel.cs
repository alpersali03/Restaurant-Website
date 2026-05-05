using Restaurant.DTOs;

namespace Restaurant.Models
{
    public class HomeIndexViewModel
    {
        public List<ProductDto> FeaturedProducts { get; set; } = new();
        public List<CategoryFormDto> Categories { get; set; } = new();
        public List<ReviewFormDto> Reviews { get; set; } = new();
    }
}
