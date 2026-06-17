using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Restaurant.Data;
using Restaurant.Data.Models;
using Restaurant.DTOs;

namespace Restaurant.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext data;
        private readonly IMapper _mapper;

        public ProductService(ApplicationDbContext data, IMapper mapper)
        {
            this.data = data;
            _mapper = mapper;
        }

        public void Add(ProductFormDto productFormDto)
        {
            if (string.IsNullOrEmpty(productFormDto.Name) || string.IsNullOrEmpty(productFormDto.Description))
            {
                throw new Exception("The product cannot be added");
            }

            Product mapped = _mapper.Map<Product>(productFormDto);
            this.data.Add(mapped);
            data.SaveChanges();
        }

        public void Delete(int id)
        {
            var product = GetById(id);
            if (product == null)
            {
                throw new ArgumentException("The product not found!");
            }

            this.data.Remove(product);
            data.SaveChanges();
        }

        public void Edit(ProductFormDto productFormDto)
        {
            var product = this.data.Products.FirstOrDefault(p => p.Id == productFormDto.Id);
            if (product == null)
            {
                throw new ArgumentException("Product doesn't exist");
            }

            _mapper.Map(productFormDto, product);
            data.SaveChanges();
        }

        public List<ProductDto> GetAll()
        {
            var products = data.Products.Include(c => c.Category).ToList();
            return _mapper.Map<List<ProductDto>>(products);
        }

        public Product? GetById(int id)
        {
            return this.data.Products.FirstOrDefault(x => x.Id == id);
        }

        public Product? GetDetails(int id)
        {
            return this.data.Products
                .Include(c => c.Category)
                .FirstOrDefault(x => x.Id == id);
        }
    }
}
