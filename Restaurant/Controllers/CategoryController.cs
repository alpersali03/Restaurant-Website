using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Restaurant.DTOs;
using Restaurant.Services;

namespace Restaurant.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ICategoryService _categoryService;

        public CategoryController(IMapper mapper, ICategoryService categoryService)
        {
            this._mapper = mapper;
            this._categoryService = categoryService;
        }

        public IActionResult Index()
        {
            var categories = _categoryService.GetAll();
            return View(categories);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View(new CategoryFormDto());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(CategoryFormDto categoryFormDto)
        {
            if (!ModelState.IsValid)
            {
                return View(categoryFormDto);
            }

            _categoryService.Add(categoryFormDto);
            return RedirectToAction("GetAll");
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var categories = _categoryService.GetAll();
            var catDto = _mapper.Map<List<CategoryFormDto>>(categories);
            return View(catDto);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var category = _categoryService.GetById(id);
            if (category == null)
            {
                return NotFound();
            }

            var catDto = _mapper.Map<CategoryFormDto>(category);
            return View(catDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CategoryDto category)
        {
            if (!ModelState.IsValid)
            {
                var categoryEntity = _categoryService.GetById(category.Id);
                if (categoryEntity == null)
                {
                    return NotFound();
                }

                return View(_mapper.Map<CategoryFormDto>(categoryEntity));
            }

            _categoryService.Edit(category);
            return RedirectToAction("GetAll");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _categoryService.Delete(id);
            return RedirectToAction("GetAll");
        }
    }
}
