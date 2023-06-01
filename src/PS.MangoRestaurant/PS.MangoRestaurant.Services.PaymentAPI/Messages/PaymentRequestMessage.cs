namespace PS.MangoRestaurant.Services.PaymentAPI.Messages
{
    public class PaymentRequestMessage
    {
        public int OrderId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string CardNumber { get; set; } = string.Empty;
        public string CVV { get; set; } = string.Empty;
        public string ExpiryMonthYear { get; set; } = string.Empty;
        public double OrderTotal { get; set; }
    }
}
