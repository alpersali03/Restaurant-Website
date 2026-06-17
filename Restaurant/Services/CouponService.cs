using AutoMapper;
using Restaurant.Data;
using Restaurant.Data.Models;
using Restaurant.DTOs;

namespace Restaurant.Services
{
    public class CouponService : ICouponService
    {
        private readonly ApplicationDbContext data;
        private readonly IMapper mapper;

        public CouponService(ApplicationDbContext data, IMapper mapper)
        {
            this.data = data;
            this.mapper = mapper;
        }

        public void Add(CouponFormDto couponDto)
        {
            if (string.IsNullOrWhiteSpace(couponDto.Code))
            {
                throw new ArgumentException("Coupon code is required.", nameof(couponDto));
            }

            var mapped = mapper.Map<Coupon>(couponDto);
            data.Coupons.Add(mapped);
            data.SaveChanges();
        }

        public void Delete(int id)
        {
            var coupon = GetById(id);
            if (coupon == null)
            {
                throw new ArgumentException("Coupon not found.", nameof(id));
            }

            data.Coupons.Remove(coupon);
            data.SaveChanges();
        }

        public void Edit(CouponDto dto)
        {
            var coupon = data.Coupons.FirstOrDefault(item => item.Id == dto.Id);
            if (coupon == null)
            {
                throw new ArgumentException("Coupon not found.", nameof(dto));
            }

            mapper.Map(dto, coupon);
            data.SaveChanges();
        }

        public List<CouponFormDto> GetAll()
        {
            return mapper.Map<List<CouponFormDto>>(data.Coupons.OrderBy(item => item.Code).ToList());
        }

        public Coupon? GetById(int id)
        {
            return data.Coupons.FirstOrDefault(item => item.Id == id);
        }
    }
}
