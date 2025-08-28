using Restaurant.Data;
using Restaurant.Data.Models;

namespace Restaurant.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext data;

        public CategoryService(ApplicationDbContext data)
        {
            this.data = data;   
        }
        public List<Category> GetAll()
        {
            var category = this.data.Categories.ToList();
            return category;    
        }
    }
}
