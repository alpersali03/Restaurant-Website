using Restaurant.DTOs;

namespace Restaurant.Services
{
    public interface IReviewService
    {
        List<ReviewFormDto> GetAll();
        ReviewFormDto BuildCreateModel();
        ReviewFormDto? BuildEditModel(int id);
        void Add(ReviewFormDto reviewFormDto);
        void Edit(ReviewFormDto reviewFormDto);
        void Delete(int id);
    }
}
