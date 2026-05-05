namespace Restaurant.Services.Payments
{
    public sealed class DemoPaymentGateway : IPaymentGateway
    {
        public Task<PaymentGatewayResult> CreateSessionAsync(PaymentSessionRequest request, CancellationToken cancellationToken = default)
        {
            var sessionId = $"demo_{Guid.NewGuid():N}";
            var redirectUrl = request.SuccessUrl.Replace("{CHECKOUT_SESSION_ID}", sessionId, StringComparison.Ordinal);

            return Task.FromResult(new PaymentGatewayResult
            {
                Provider = "Demo",
                SessionId = sessionId,
                RedirectUrl = redirectUrl
            });
        }

        public Task<PaymentVerificationResult> VerifySessionAsync(string sessionId, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(new PaymentVerificationResult
            {
                IsPaid = sessionId.StartsWith("demo_", StringComparison.OrdinalIgnoreCase),
                ProviderPaymentId = sessionId,
                RawStatus = "paid"
            });
        }
    }
}
