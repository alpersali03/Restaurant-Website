using Microsoft.AspNetCore.Mvc;
using Restaurant.Data;
using Restaurant.Data.Models;
using Restaurant.DTOs;
using AutoMapper;

namespace Restaurant.Controllers
{
    public class CategoryController : Controller
    {

        private readonly ApplicationDbContext data;
        private readonly IMapper _mapper;

        public CategoryController(ApplicationDbContext data, IMapper mapper)
        {
            this.data = data;
            this._mapper = mapper;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Add()
        {
            CategoryFormDto categoryFormDto = new CategoryFormDto();
			categoryFormDto.Products = data.Products.ToList();

			return View(categoryFormDto);

        }
        [HttpPost] 
        public IActionResult Add(CategoryFormDto categoryFormDto)
        {
            if (string.IsNullOrEmpty(categoryFormDto.Name) || string.IsNullOrEmpty(categoryFormDto.Name))
            {
                throw new Exception("The category already exists");
            }
            var category = new Category();
            category.Name = categoryFormDto.Name;
            category.Products = categoryFormDto.Products;
            category.IconUrl = categoryFormDto.IconUrl;

            this.data.Add(category);
            data.SaveChanges();
            return RedirectToAction("GetAll");
        }
        [HttpGet]
        public IActionResult Getall()
        {
            var categories = data.Categories.ToList();
            var catDto = _mapper.Map<List<CategoryFormDto>>(categories);
            return View(catDto);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var category = this.data.Categories.FirstOrDefault(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            var catDto = _mapper.Map<CategoryFormDto>(category);
            return View(catDto);  
        }
        [HttpPost]
        public IActionResult Edit(CategoryFormDto category)
        {
            var existingCategory = this.data.Categories.FirstOrDefault(c=>c.Id == category.Id); 

            if (existingCategory == null)
            {
                return NotFound();
            }
            existingCategory.Name = category.Name;  
            existingCategory.IconUrl = category.IconUrl;

            data.SaveChanges();
            return RedirectToAction("GetAll");
            
        }
		[HttpGet]
		public IActionResult Delete(int id)
		{
			var deletingCategory = this.data.Categories.FirstOrDefault(x => x.Id == id);
            if (deletingCategory == null)
            {
                return NotFound();
            }
			this.data.Remove(deletingCategory);
			data.SaveChanges();
			return RedirectToAction("getall");

		}
		//[HttpGet]
		//public IActionResult Search(string keyword)
		//{
		//	if (string.IsNullOrEmpty(keyword))
		//	{
		//		var allCategories = this.data.Categories.ToList();
		//		return View("GetAll", allCategories);
		//	}

		//	var matchedCategories = this.data.Categories
		//		.Where(c => c.Name.ToLower().Contains(keyword.ToLower()))
		//		.ToList();

		//	return View("GetAll", matchedCategories);
		//}

	}
}

