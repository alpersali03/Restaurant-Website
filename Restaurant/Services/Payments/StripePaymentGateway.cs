using Microsoft.Extensions.Options;
using Restaurant.Options;
using Stripe;
using Stripe.Checkout;

namespace Restaurant.Services.Payments
{
    public sealed class StripePaymentGateway : IPaymentGateway
    {
        private readonly StripeOptions _options;

        public StripePaymentGateway(IOptions<PaymentGatewayOptions> options)
        {
            _options = options.Value.Stripe;
        }

        public async Task<PaymentGatewayResult> CreateSessionAsync(PaymentSessionRequest request, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(_options.SecretKey))
            {
                throw new InvalidOperationException("Stripe secret key is not configured.");
            }

            StripeConfiguration.ApiKey = _options.SecretKey;

            var service = new SessionService();
            var session = await service.CreateAsync(new SessionCreateOptions
            {
                Mode = "payment",
                SuccessUrl = request.SuccessUrl,
                CancelUrl = request.CancelUrl,
                CustomerEmail = request.CustomerEmail,
                LineItems = request.Items.Select(item => new SessionLineItemOptions
                {
                    Quantity = item.Quantity,
                    PriceData = new SessionLineItemPriceDataOptions
                    {
                        Currency = request.Currency,
                        UnitAmountDecimal = item.UnitAmount * 100m,
                        ProductData = new SessionLineItemPriceDataProductDataOptions
                        {
                            Name = item.Name
                        }
                    }
                }).ToList()
            }, cancellationToken: cancellationToken);

            return new PaymentGatewayResult
            {
                Provider = "Stripe",
                SessionId = session.Id,
                RedirectUrl = session.Url
            };
        }

        public async Task<PaymentVerificationResult> VerifySessionAsync(string sessionId, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(_options.SecretKey))
            {
                throw new InvalidOperationException("Stripe secret key is not configured.");
            }

            StripeConfiguration.ApiKey = _options.SecretKey;

            var service = new SessionService();
            var session = await service.GetAsync(sessionId, cancellationToken: cancellationToken);

            return new PaymentVerificationResult
            {
                IsPaid = string.Equals(session.PaymentStatus, "paid", StringComparison.OrdinalIgnoreCase),
                ProviderPaymentId = session.PaymentIntentId,
                RawStatus = session.PaymentStatus
            };
        }
    }
}
