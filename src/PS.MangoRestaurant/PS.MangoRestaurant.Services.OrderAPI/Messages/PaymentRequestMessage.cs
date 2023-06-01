using PS.MangoRestaurant.MessageBus;

namespace PS.MangoRestaurant.Services.OrderAPI.Messages
{
    public class PaymentRequestMessage : BaseMessage
    {
        public int OrderId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string CardNumber { get; set; } = string.Empty;
        public string CVV { get; set; } = string.Empty;
        public string ExpiryMonthYear { get; set; } = string.Empty;
        public double OrderTotal { get; set; }
    }
}
