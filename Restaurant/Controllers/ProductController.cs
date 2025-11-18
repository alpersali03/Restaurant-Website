using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Restaurant.Data;
using Restaurant.Data.Models;
using Restaurant.DTOs;
using Restaurant.Services;

namespace Restaurant.Controllers
{
	//[Authorize]
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext data;
        private readonly IMapper _mapper;	
		private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;

        public ProductController(ApplicationDbContext data, IMapper mapper, ICategoryService categoryService, IProductService productService)
        {
            this.data = data;
            this._mapper = mapper;
			this._categoryService = categoryService;
            this._productService = productService;
        }
		[HttpGet]
		public IActionResult Add()
		{
			ProductFormDto productFormDto = new ProductFormDto();
            productFormDto.Categories = _categoryService.GetAll();
			return View(productFormDto);

		}
		[HttpPost]
		public IActionResult Add(ProductFormDto productFormDto)
		{
			if (string.IsNullOrEmpty(productFormDto.Name) || string.IsNullOrEmpty(productFormDto.Description))
			{
				throw new Exception("The category already exists");
			}

			_productService.Add(productFormDto);
			return RedirectToAction("GetAll");
		}
		[HttpGet]
        public IActionResult Getall()
        {
            var products = _productService.GetAll();
            
            return View(products);
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
            productDto.Categories = _categoryService.GetAll();

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

            if (!ModelState.IsValid)
            {
                
                product.Categories = _categoryService.GetAll();
                return View(product);
            }

            existingProduct.Name = product.Name;
            existingProduct.Description = product.Description;
            existingProduct.ImageUrl = product.ImageUrl;
            existingProduct.Price = product.Price;
            existingProduct.IsAvailable = product.IsAvailable;
            existingProduct.CategoryId = product.CategoryId;

            data.SaveChanges();
            return RedirectToAction("GetAll");
        }
		[HttpGet]
		public IActionResult Details(int id)
		{
            var product = _productService.GetDetails(id);
			return View(product);
		}

		[HttpGet]
		public IActionResult Delete(int id)
		{
			_productService.Delete(id);
            return RedirectToAction("getall");

		}

	}

}
