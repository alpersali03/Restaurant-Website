namespace Restaurant.Options
{
    public class PaymentGatewayOptions
    {
        public const string SectionName = "Payments";

        public string Gateway { get; set; } = "Demo";
        public string Currency { get; set; } = "usd";
        public string ApplicationBaseUrl { get; set; } = "https://localhost:7000";
        public StripeOptions Stripe { get; set; } = new();
    }

    public class StripeOptions
    {
        public string SecretKey { get; set; } = string.Empty;
    }
}
