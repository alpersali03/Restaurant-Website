using AutoMapper;
using Restaurant.Data.Models;
using Restaurant.DTOs;

namespace Restaurant.Extensions
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CategoryFormDto>();
            CreateMap<CategoryFormDto, Category>();
            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>();

            CreateMap<Coupon, CouponFormDto>();
            CreateMap<CouponFormDto, Coupon>()
                .ForMember(destination => destination.Percentage, options => options.MapFrom(source => (PercentageRate)source.Percentage));
            CreateMap<Coupon, CouponDto>();
            CreateMap<CouponDto, Coupon>();

            CreateMap<Order, OrderFormDto>();
            CreateMap<OrderFormDto, Order>();
            CreateMap<Order, OrderDto>();
            CreateMap<OrderDto, Order>();

            CreateMap<Payment, PaymentFormDto>();
            CreateMap<Payment, PaymentDto>();

            CreateMap<ProductFormDto, Product>();
            CreateMap<Product, ProductFormDto>();
            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>();

            CreateMap<ReviewFormDto, Review>();
            CreateMap<Review, ReviewFormDto>()
                .ForMember(destination => destination.ProductName, options => options.MapFrom(source => source.Product != null ? source.Product.Name : string.Empty))
                .ForMember(destination => destination.Products, options => options.Ignore());

            CreateMap<ReservationFormDto, Reservation>();
            CreateMap<Reservation, ReservationFormDto>();
            CreateMap<ReservationDto, Reservation>();
            CreateMap<Reservation, ReservationDto>();

            CreateMap<OrderItem, OrderItemFormDto>();
            CreateMap<OrderItemFormDto, OrderItem>();
        }
    }
}
