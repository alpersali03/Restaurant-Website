using Restaurant.Data.Models;
using Restaurant.DTOs;

namespace Restaurant.Services
{
    public interface ICouponService
    {
        List<CouponFormDto> GetAll();
        void Add(CouponFormDto couponDto);
        void Edit(CouponDto dto);
        void Delete(int id);
        Coupon? GetById(int id);
    }
}
