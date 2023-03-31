namespace PS.MangoRestaurant.Services.ShoppingCartAPI.Models.Dto
{
    public class CartDto
    {
        public CartHeader CartHeader { get; set; } = null!;
        public IEnumerable<CartDetails> CartDetails { get; set; } = null!;
    }
}
