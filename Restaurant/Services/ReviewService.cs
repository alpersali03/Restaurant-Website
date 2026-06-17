using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Restaurant.Data;
using Restaurant.Data.Models;
using Restaurant.DTOs;

namespace Restaurant.Services
{
    public class ReviewService : IReviewService
    {
        private readonly ApplicationDbContext data;
        private readonly IMapper mapper;

        public ReviewService(ApplicationDbContext data, IMapper mapper)
        {
            this.data = data;
            this.mapper = mapper;
        }

        public List<ReviewFormDto> GetAll()
        {
            return data.Reviews
                .Include(review => review.Product)
                .Select(review => new ReviewFormDto
                {
                    Id = review.Id,
                    CustomerName = review.CustomerName,
                    Rating = review.Rating,
                    Comment = review.Comment,
                    CreatedAt = review.CreatedAt,
                    ProductId = review.ProductId,
                    ProductName = review.Product != null ? review.Product.Name : string.Empty
                })
                .ToList();
        }

        public ReviewFormDto BuildCreateModel()
        {
            return new ReviewFormDto
            {
                CreatedAt = DateTime.UtcNow,
                Products = data.Products.OrderBy(product => product.Name).ToList()
            };
        }

        public ReviewFormDto? BuildEditModel(int id)
        {
            var review = data.Reviews.FirstOrDefault(item => item.Id == id);
            if (review == null)
            {
                return null;
            }

            var dto = mapper.Map<ReviewFormDto>(review);
            dto.Products = data.Products.OrderBy(product => product.Name).ToList();
            return dto;
        }

        public void Add(ReviewFormDto reviewFormDto)
        {
            EnsureProductExists(reviewFormDto.ProductId);

            var review = new Review
            {
                CustomerName = reviewFormDto.CustomerName,
                Rating = reviewFormDto.Rating,
                Comment = reviewFormDto.Comment,
                CreatedAt = reviewFormDto.CreatedAt,
                ProductId = reviewFormDto.ProductId
            };

            data.Reviews.Add(review);
            data.SaveChanges();
        }

        public void Edit(ReviewFormDto reviewFormDto)
        {
            EnsureProductExists(reviewFormDto.ProductId);

            var existingReview = data.Reviews.FirstOrDefault(item => item.Id == reviewFormDto.Id);
            if (existingReview == null)
            {
                throw new ArgumentException("Review not found.", nameof(reviewFormDto));
            }

            existingReview.CustomerName = reviewFormDto.CustomerName;
            existingReview.Comment = reviewFormDto.Comment;
            existingReview.Rating = reviewFormDto.Rating;
            existingReview.CreatedAt = reviewFormDto.CreatedAt;
            existingReview.ProductId = reviewFormDto.ProductId;
            data.SaveChanges();
        }

        public void Delete(int id)
        {
            var review = data.Reviews.FirstOrDefault(item => item.Id == id);
            if (review == null)
            {
                throw new ArgumentException("Review not found.", nameof(id));
            }

            data.Reviews.Remove(review);
            data.SaveChanges();
        }

        private void EnsureProductExists(int productId)
        {
            if (!data.Products.Any(item => item.Id == productId))
            {
                throw new ArgumentException("Selected product not found.", nameof(productId));
            }
        }
    }
}
