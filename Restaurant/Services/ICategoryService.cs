using Restaurant.Data.Models;
using Restaurant.DTOs;

namespace Restaurant.Services
{
    public interface ICategoryService
    {
        List<CategoryFormDto> GetAll();
        void Add(CategoryFormDto dto);
        void Edit(CategoryDto categoryDto);
        void Delete(int id);
        Category? GetById(int id);
    }
}
