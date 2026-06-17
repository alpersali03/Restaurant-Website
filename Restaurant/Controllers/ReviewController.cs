using Microsoft.AspNetCore.Mvc;
using Restaurant.DTOs;
using Restaurant.Services;

namespace Restaurant.Controllers
{
    public class ReviewController : Controller
    {
        private readonly IReviewService reviewService;

        public ReviewController(IReviewService reviewService)
        {
            this.reviewService = reviewService;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View(reviewService.BuildCreateModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(ReviewFormDto reviewFormDto)
        {
            if (!ModelState.IsValid)
            {
                reviewFormDto.Products = reviewService.BuildCreateModel().Products;
                return View(reviewFormDto);
            }

            reviewService.Add(reviewFormDto);
            return RedirectToAction(nameof(GetAll));
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return View(reviewService.GetAll());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var dto = reviewService.BuildEditModel(id);
            if (dto == null)
            {
                return NotFound();
            }

            return View(dto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ReviewFormDto reviewFormDto)
        {
            if (!ModelState.IsValid)
            {
                reviewFormDto.Products = reviewService.BuildCreateModel().Products;
                return View(reviewFormDto);
            }

            reviewService.Edit(reviewFormDto);
            return RedirectToAction(nameof(GetAll));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            reviewService.Delete(id);
            return RedirectToAction(nameof(GetAll));
        }
    }
}
