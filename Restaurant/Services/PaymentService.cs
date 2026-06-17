using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Restaurant.Data;
using Restaurant.DTOs;

namespace Restaurant.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly ApplicationDbContext data;
        private readonly IMapper mapper;

        public PaymentService(ApplicationDbContext data, IMapper mapper)
        {
            this.data = data;
            this.mapper = mapper;
        }

        public IReadOnlyList<PaymentDto> GetAll()
        {
            return data.Payments
                .Include(payment => payment.Order)
                .OrderByDescending(payment => payment.CreatedAt)
                .ProjectTo<PaymentDto>(mapper.ConfigurationProvider)
                .ToList();
        }

        public PaymentDto? GetById(int id)
        {
            return data.Payments
                .Include(payment => payment.Order)
                .Where(payment => payment.Id == id)
                .ProjectTo<PaymentDto>(mapper.ConfigurationProvider)
                .FirstOrDefault();
        }
    }
}
