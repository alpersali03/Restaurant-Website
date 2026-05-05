namespace Restaurant.Services.Payments
{
    public interface IPaymentGateway
    {
        Task<PaymentGatewayResult> CreateSessionAsync(PaymentSessionRequest request, CancellationToken cancellationToken = default);
        Task<PaymentVerificationResult> VerifySessionAsync(string sessionId, CancellationToken cancellationToken = default);
    }
}
