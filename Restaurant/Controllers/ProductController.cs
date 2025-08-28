using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Data;
using Restaurant.Data.Models;
using Restaurant.DTOs;

namespace Restaurant.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext data;
        private readonly IMapper _mapper;	

        public ProductController(ApplicationDbContext data, IMapper mapper)
        {
            this.data = data;
            this._mapper = mapper;
        }
		[HttpGet]
		public IActionResult Add()
		{
			ProductFormDto productFormDto = new ProductFormDto();
			productFormDto.Categories = _mapper.Map<List<CategoryFormDto>>(data.Categories.ToList());
			return View(productFormDto);

		}
		[HttpPost]
		public IActionResult Add(ProductFormDto productFormDto)
		{
			if (string.IsNullOrEmpty(productFormDto.Name) || string.IsNullOrEmpty(productFormDto.Description))
			{
				throw new Exception("The category already exists");
			}
			Product mapped = _mapper.Map<Product>(productFormDto);

			this.data.Add(mapped);
			data.SaveChanges();
			return RedirectToAction("GetAll");
		}
		[HttpGet]
        public IActionResult Getall()
        {
            var products = data.Products.ToList();
            var productDto = _mapper.Map<List<ProductFormDto>>(products);
            return View(productDto);
        }
		[HttpGet]
		public IActionResult Edit(int id)
		{
			var product = this.data.Products.FirstOrDefault(p => p.Id == id);
			if (product == null)
			{
				return NotFound();
			}
			var productDto = _mapper.Map<ProductFormDto>(product);
			return View(productDto);
		}
		[HttpPost]
		public IActionResult Edit(ProductFormDto product)
		{
			var existingProduct = this.data.Products.FirstOrDefault(c => c.Id == product.Id);

			if (existingProduct == null)
			{
				return NotFound();
			}

			existingProduct.Name = product.Name;
			//existingProduct.Category = product.Categories;
			existingProduct.ImageUrl = product.ImageUrl;
			existingProduct.Price = product.Price;
			data.SaveChanges();
			return RedirectToAction("GetAll");

		}
		[HttpGet]
		public IActionResult Delete(int id)
		{
			var deletingProduct = this.data.Products.FirstOrDefault(x => x.Id == id);
			if (deletingProduct == null)
			{
				return NotFound();
			}
			this.data.Remove(deletingProduct);
			data.SaveChanges();
			return RedirectToAction("getall");

		}

	}

}
