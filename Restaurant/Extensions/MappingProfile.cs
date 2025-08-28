using AutoMapper;
using Restaurant.Data.Models;
using Restaurant.DTOs;

namespace Restaurant.Extensions
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // CreateMap<from,desteny>();
            CreateMap<Category, CategoryFormDto>();
            CreateMap<CategoryFormDto, Category>();
            CreateMap<Coupon, CouponFormDto>();
            CreateMap<CouponFormDto, Coupon>();
            CreateMap<Order, OrderFormDto>();
            CreateMap<OrderFormDto, Order>();
            CreateMap<PaymentFormDto, Payment>();
            CreateMap<Payment, PaymentFormDto>();
            CreateMap<ProductFormDto, Product>();
            CreateMap<Product, ProductFormDto>();
			CreateMap<ReviewFormDto, Review>();
			CreateMap<Review, ReviewFormDto>();
			CreateMap<ReservationFormDto, Reservation>();
			CreateMap<Reservation, ReservationFormDto>();

		}
    }
}
