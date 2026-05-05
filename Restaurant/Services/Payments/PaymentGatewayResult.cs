namespace Restaurant.Services.Payments
{
    public sealed class PaymentGatewayResult
    {
        public string Provider { get; init; } = string.Empty;
        public string SessionId { get; init; } = string.Empty;
        public string RedirectUrl { get; init; } = string.Empty;
    }

    public sealed class PaymentVerificationResult
    {
        public bool IsPaid { get; init; }
        public string? ProviderPaymentId { get; init; }
        public string? RawStatus { get; init; }
    }
}
