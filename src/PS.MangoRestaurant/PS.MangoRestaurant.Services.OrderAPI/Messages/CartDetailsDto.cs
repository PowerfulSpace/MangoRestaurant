namespace PS.MangoRestaurant.Services.OrderAPI.Messages
{
    public class CartDetailsDto
    {
        public int CartDetailsId { get; set; }
        public int CartHeaderId { get; set; }
        public int ProductId { get; set; }
        public virtual ProductDto Product { get; set; } = null!;
        public int Count { get; set; }
    }
}
