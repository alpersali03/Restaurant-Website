using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Restaurant.Data;
using Restaurant.Data.Models;
using Restaurant.DTOs;
using Restaurant.Options;
using Restaurant.Services.Payments;

namespace Restaurant.Services
{
    public class CheckoutService : ICheckoutService
    {
        private readonly ApplicationDbContext context;
        private readonly IPaymentGateway paymentGateway;
        private readonly PaymentGatewayOptions paymentOptions;

        public CheckoutService(
            ApplicationDbContext context,
            IPaymentGateway paymentGateway,
            IOptions<PaymentGatewayOptions> paymentOptions)
        {
            this.context = context;
            this.paymentGateway = paymentGateway;
            this.paymentOptions = paymentOptions.Value;
        }

        public CheckoutDto BuildCheckout(string userId, int orderId)
        {
            var order = GetOwnedOrder(userId, orderId);

            return new CheckoutDto
            {
                OrderId = order.Id,
                OrderTotal = order.OrderItems.Sum(item => (item.Product?.Price ?? 0m) * item.Quantity),
                Items = order.OrderItems.Select(item => new CheckoutItemDto
                {
                    OrderItemId = item.Id,
                    ProductName = item.Product?.Name ?? string.Empty,
                    Price = item.Product?.Price ?? 0m,
                    Quantity = item.Quantity
                }).ToList()
            };
        }

        public async Task<string> StartCheckoutAsync(string userId, CheckoutDto dto, CancellationToken cancellationToken = default)
        {
            var order = GetOwnedOrder(userId, dto.OrderId);

            var checkout = context.Checkouts.FirstOrDefault(existing => existing.OrderId == order.Id);
            if (checkout == null)
            {
                checkout = new Checkout
                {
                    OrderId = order.Id
                };

                context.Checkouts.Add(checkout);
            }

            checkout.FullName = dto.FullName;
            checkout.Email = dto.Email;
            checkout.Address = dto.Address;
            checkout.CouponCode = dto.CouponCode;

            var request = new PaymentSessionRequest
            {
                OrderId = order.Id,
                Amount = order.OrderItems.Sum(item => (item.Product?.Price ?? 0m) * item.Quantity),
                Currency = paymentOptions.Currency,
                CustomerEmail = dto.Email,
                CustomerName = dto.FullName,
                SuccessUrl = $"{paymentOptions.ApplicationBaseUrl.TrimEnd('/')}/Checkout/Success?sessionId={{CHECKOUT_SESSION_ID}}",
                CancelUrl = $"{paymentOptions.ApplicationBaseUrl.TrimEnd('/')}/Checkout/Cancel?sessionId={{CHECKOUT_SESSION_ID}}",
                Items = order.OrderItems.Select(item => new PaymentSessionLineItem
                {
                    Name = item.Product?.Name ?? $"Order item {item.Id}",
                    UnitAmount = item.Product?.Price ?? 0m,
                    Quantity = item.Quantity
                }).ToList()
            };

            var gatewayResult = await paymentGateway.CreateSessionAsync(request, cancellationToken);

            var payment = context.Payments.FirstOrDefault(existing => existing.ProviderSessionId == gatewayResult.SessionId);
            if (payment == null)
            {
                payment = new Payment
                {
                    OrderId = order.Id,
                    CreatedAt = DateTime.UtcNow
                };
                context.Payments.Add(payment);
            }

            payment.Amount = request.Amount;
            payment.Currency = request.Currency;
            payment.Provider = gatewayResult.Provider;
            payment.ProviderSessionId = gatewayResult.SessionId;
            payment.Status = PaymentStatus.Pending;
            payment.ProviderPaymentId = null;
            payment.CompletedAt = null;

            await context.SaveChangesAsync(cancellationToken);
            return gatewayResult.RedirectUrl;
        }

        public async Task<bool> ConfirmPaymentAsync(string userId, string sessionId, CancellationToken cancellationToken = default)
        {
            var payment = await context.Payments
                .Include(item => item.Order)
                .ThenInclude(order => order!.OrderItems)
                .ThenInclude(item => item.Product)
                .FirstOrDefaultAsync(item => item.ProviderSessionId == sessionId && item.Order != null && item.Order.IdentityUserId == userId, cancellationToken);

            if (payment == null || payment.Order == null)
            {
                return false;
            }

            var verification = await paymentGateway.VerifySessionAsync(sessionId, cancellationToken);
            if (!verification.IsPaid)
            {
                payment.Status = PaymentStatus.Failed;
                await context.SaveChangesAsync(cancellationToken);
                return false;
            }

            payment.Status = PaymentStatus.Completed;
            payment.ProviderPaymentId = verification.ProviderPaymentId;
            payment.CompletedAt = DateTime.UtcNow;

            payment.Order.Status = OrderStatus.Completed;
            payment.Order.OrderTime = DateTime.UtcNow;
            payment.Order.TotalAmount = payment.Order.OrderItems.Sum(item => (item.Product?.Price ?? 0m) * item.Quantity);

            await context.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task CancelPaymentAsync(string userId, string sessionId, CancellationToken cancellationToken = default)
        {
            var payment = await context.Payments
                .Include(item => item.Order)
                .FirstOrDefaultAsync(item => item.ProviderSessionId == sessionId && item.Order != null && item.Order.IdentityUserId == userId, cancellationToken);

            if (payment == null || payment.Status == PaymentStatus.Completed)
            {
                return;
            }

            payment.Status = PaymentStatus.Cancelled;
            await context.SaveChangesAsync(cancellationToken);
        }

        private Order GetOwnedOrder(string userId, int orderId)
        {
            if (string.IsNullOrWhiteSpace(userId))
            {
                throw new UnauthorizedAccessException("User is required.");
            }

            var order = context.Orders
                .Include(item => item.OrderItems)
                .ThenInclude(orderItem => orderItem.Product)
                .FirstOrDefault(item => item.Id == orderId && item.IdentityUserId == userId);

            if (order == null)
            {
                throw new InvalidOperationException("Order not found.");
            }

            return order;
        }
    }
}
