using Restaurant.Data.Models;
using Restaurant.DTOs;

namespace Restaurant.Services
{
    public interface IProductService
    {
        List<ProductDto> GetAll();
        void Add(ProductFormDto productFormDto);
        void Delete(int id);
        Product? GetById(int id);
        void Edit(ProductFormDto productFormDto);
        Product? GetDetails(int id);
    }
}
