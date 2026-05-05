using Restaurant.DTOs;

namespace Restaurant.Services
{
    public interface ICheckoutService
    {
        CheckoutDto BuildCheckout(string userId, int orderId);
        Task<string> StartCheckoutAsync(string userId, CheckoutDto checkoutDto, CancellationToken cancellationToken = default);
        Task<bool> ConfirmPaymentAsync(string userId, string sessionId, CancellationToken cancellationToken = default);
        Task CancelPaymentAsync(string userId, string sessionId, CancellationToken cancellationToken = default);
    }
}
