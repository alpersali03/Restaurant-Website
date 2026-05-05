using Microsoft.Extensions.Options;
using Restaurant.Options;

namespace Restaurant.Services.Payments
{
    public sealed class ConfigurablePaymentGateway : IPaymentGateway
    {
        private readonly DemoPaymentGateway _demoPaymentGateway;
        private readonly StripePaymentGateway _stripePaymentGateway;
        private readonly PaymentGatewayOptions _options;

        public ConfigurablePaymentGateway(
            DemoPaymentGateway demoPaymentGateway,
            StripePaymentGateway stripePaymentGateway,
            IOptions<PaymentGatewayOptions> options)
        {
            _demoPaymentGateway = demoPaymentGateway;
            _stripePaymentGateway = stripePaymentGateway;
            _options = options.Value;
        }

        public Task<PaymentGatewayResult> CreateSessionAsync(PaymentSessionRequest request, CancellationToken cancellationToken = default)
        {
            return ResolveGateway().CreateSessionAsync(request, cancellationToken);
        }

        public Task<PaymentVerificationResult> VerifySessionAsync(string sessionId, CancellationToken cancellationToken = default)
        {
            return ResolveGateway().VerifySessionAsync(sessionId, cancellationToken);
        }

        private IPaymentGateway ResolveGateway()
        {
            return string.Equals(_options.Gateway, "Stripe", StringComparison.OrdinalIgnoreCase)
                ? _stripePaymentGateway
                : _demoPaymentGateway;
        }
    }
}
