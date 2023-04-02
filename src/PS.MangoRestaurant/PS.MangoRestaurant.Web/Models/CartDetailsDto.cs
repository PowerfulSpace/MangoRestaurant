namespace PS.MangoRestaurant.Web.Models
{
    public class CartDetailsDto
    {
        public int CartDetailsId { get; set; }
        public int CartHeaderId { get; set; }
        public virtual CartHeaderDto CartHeader { get; set; } = null!;
        public int ProductId { get; set; }
        public virtual ProductDto Product { get; set; } = null!;
        public int Count { get; set; }
    }
}
