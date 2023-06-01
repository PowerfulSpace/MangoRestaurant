namespace PS.MangoRestaurant.Services.OrderAPI.Messages
{
    public class UpdatePaymentRequestMessage
    {
        public int OrderId { get; set; }
        public bool Status { get; set; }
    }
}
