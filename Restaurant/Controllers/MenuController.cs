using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restaurant.Data;
using Restaurant.DTOs;
using Restaurant.Services;

namespace Restaurant.Controllers
{
    public class MenuController : Controller
    {
        private readonly ApplicationDbContext data;
        private readonly IMapper _mapper;
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;

        public MenuController(ApplicationDbContext data, IMapper mapper, ICategoryService categoryService, IProductService productService)
        {
            this.data = data;
            this._mapper = mapper;
            this._categoryService = categoryService;
            this._productService = productService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var products = _productService.GetAll();

            //var category = this.data.Categories.Include(p=>p.Products).ToList();
            return View(products);

        }
        

    }
}
