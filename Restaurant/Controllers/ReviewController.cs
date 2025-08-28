using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restaurant.Data;
using Restaurant.Data.Models;
using Restaurant.DTOs;

namespace Restaurant.Controllers
{
    public class ReviewController : Controller
    {
        private readonly ApplicationDbContext data;
        private readonly IMapper _mapper;

        public ReviewController(ApplicationDbContext data, IMapper mapper)
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
            var reviewFormDto = new ReviewFormDto
            {
                Products = data.Products.ToList()
            };

            return View(reviewFormDto);
        }

        [HttpPost]
        public IActionResult Add(ReviewFormDto reviewFormDto)
        {
            if (!ModelState.IsValid)
            {
                reviewFormDto.Products = data.Products.ToList();
                return View(reviewFormDto);
            }

            var product = data.Products.FirstOrDefault(p => p.Id == reviewFormDto.ProductId);
            if (product == null)
            {
                return NotFound("Selected product not found.");
            }

            var review = new Review
            {
                CustomerName = reviewFormDto.CustomerName,
                Rating = reviewFormDto.Rating,
                Comment = reviewFormDto.Comment,
                CreatedAt = reviewFormDto.CreatedAt,
                ProductId = product.Id
            };

            data.Reviews.Add(review);
            data.SaveChanges();

            return RedirectToAction("GetAll");
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var reviews = data.Reviews
                .Include(r => r.Products)
                .ToList();

            var reviewDtos = _mapper.Map<List<ReviewFormDto>>(reviews);
            return View(reviewDtos);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var review = data.Reviews.FirstOrDefault(r => r.Id == id);
            if (review == null)
            {
                return NotFound();
            }

            var dto = _mapper.Map<ReviewFormDto>(review);
            dto.Products = data.Products.ToList();

            return View(dto);
        }

        [HttpPost]
        public IActionResult Edit(ReviewFormDto reviewFormDto)
        {
            var existingReview = data.Reviews.FirstOrDefault(r => r.Id == reviewFormDto.Id);

            if (existingReview == null)
            {
                return NotFound();
            }

            var product = data.Products.FirstOrDefault(p => p.Id == reviewFormDto.ProductId);
            if (product == null)
            {
                return NotFound("Selected product not found.");
            }

            existingReview.CustomerName = reviewFormDto.CustomerName;
            existingReview.Comment = reviewFormDto.Comment;
            existingReview.Rating = reviewFormDto.Rating;
            existingReview.CreatedAt = reviewFormDto.CreatedAt;
            existingReview.ProductId = product.Id;

            data.SaveChanges();

            return RedirectToAction("GetAll");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var deletingReview = data.Reviews.FirstOrDefault(r => r.Id == id);
            if (deletingReview == null)
            {
                return NotFound();
            }

            data.Reviews.Remove(deletingReview);
            data.SaveChanges();

            return RedirectToAction("GetAll");
        }
    }
}
