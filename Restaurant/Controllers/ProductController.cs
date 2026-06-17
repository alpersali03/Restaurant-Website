using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Data;
using Restaurant.DTOs;
using Restaurant.Services;

namespace Restaurant.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext data;
        private readonly IMapper _mapper;
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;

        public ProductController(
            ApplicationDbContext data,
            IMapper mapper,
            ICategoryService categoryService,
            IProductService productService)
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
        [ValidateAntiForgeryToken]
        public IActionResult Add(ProductFormDto productFormDto)
        {
            if (!ModelState.IsValid)
            {
                productFormDto.Categories = _categoryService.GetAll();
                return View(productFormDto);
            }

            _productService.Add(productFormDto);
            return RedirectToAction("GetAll");
        }

        [HttpGet]
        public IActionResult GetAll()
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
        [ValidateAntiForgeryToken]
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
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _productService.Delete(id);
            return RedirectToAction("GetAll");
        }
    }
}
