using Restaurant.DTOs;

namespace Restaurant.Services
{
    public interface IPaymentService
    {
        IReadOnlyList<PaymentDto> GetAll();
        PaymentDto? GetById(int id);
    }
}
