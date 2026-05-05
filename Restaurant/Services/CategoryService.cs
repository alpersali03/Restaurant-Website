using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Restaurant.Data;
using Restaurant.Data.Models;
using Restaurant.DTOs;
using System.Linq.Expressions;

namespace Restaurant.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext data;
        private readonly IMapper _mapper;

        public CategoryService(ApplicationDbContext data, IMapper mapper)
        {
            this.data = data;
            this._mapper = mapper;
        }

        public void Add(CategoryFormDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Name))
            {
                throw new ArgumentNullException("The product wasn't added");
            }


            var x = _mapper.Map<Category>(dto);

            this.data.Categories.Add(x);
            data.SaveChanges();
        }
        public List<CategoryFormDto> GetAll()
        {
            var categories = data.Categories
                .Include(category => category.Products)
                .ToList();
            return _mapper.Map<List<CategoryFormDto>>(categories);
        }

        public void Edit(CategoryDto categoryDto)
        {
            var category = this.data.Categories
                .FirstOrDefault(c => c.Id == categoryDto.Id);

            if (category == null)
            {
                throw new ArgumentException("Product not found!");
            }

            var mapped = _mapper.Map(categoryDto, category);

            this.data.Categories.Update(mapped);
            this.data.SaveChanges();
        }
        public void Delete(int id)
        {
            var deletingCategory = GetById(id);

            if (deletingCategory == null)
            {
                throw new ArgumentException("The category not found");
            }
            
            this.data.Remove(deletingCategory);
            data.SaveChanges();
        }
        public Category? GetById(int id)
        {
            return this.data.Categories.Where(c => c.Id == id).FirstOrDefault();
        }
    }

}
