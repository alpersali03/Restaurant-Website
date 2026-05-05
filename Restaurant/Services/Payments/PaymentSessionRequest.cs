namespace Restaurant.Services.Payments
{
    public sealed class PaymentSessionRequest
    {
        public int OrderId { get; init; }
        public decimal Amount { get; init; }
        public string Currency { get; init; } = "usd";
        public string CustomerEmail { get; init; } = string.Empty;
        public string CustomerName { get; init; } = string.Empty;
        public string SuccessUrl { get; init; } = string.Empty;
        public string CancelUrl { get; init; } = string.Empty;
        public IReadOnlyList<PaymentSessionLineItem> Items { get; init; } = Array.Empty<PaymentSessionLineItem>();
    }

    public sealed class PaymentSessionLineItem
    {
        public string Name { get; init; } = string.Empty;
        public decimal UnitAmount { get; init; }
        public int Quantity { get; init; }
    }
}
