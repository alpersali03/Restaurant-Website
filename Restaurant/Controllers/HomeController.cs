using Microsoft.AspNetCore.Mvc;
using Restaurant.Models;
using Restaurant.Services;
using System.Diagnostics;

namespace Restaurant.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IReviewService _reviewService;

        public HomeController(
            ILogger<HomeController> logger,
            IProductService productService,
            ICategoryService categoryService,
            IReviewService reviewService)
        {
            _logger = logger;
            _productService = productService;
            _categoryService = categoryService;
            _reviewService = reviewService;
        }

        public IActionResult Index()
        {
            var model = new HomeIndexViewModel
            {
                FeaturedProducts = _productService
                    .GetAll()
                    .Where(product => product.IsAvailable)
                    .OrderByDescending(product => product.Price)
                    .Take(4)
                    .ToList(),
                Categories = _categoryService
                    .GetAll()
                    .Take(4)
                    .ToList(),
                Reviews = _reviewService
                    .GetAll()
                    .OrderByDescending(review => review.Rating)
                    .ThenByDescending(review => review.CreatedAt)
                    .Take(3)
                    .ToList()
            };

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
