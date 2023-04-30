using PS.MangoRestaurant.Services.ShoppingCartAPI.Models.Dto;

namespace PS.MangoRestaurant.Services.ShoppingCartAPI.Repository
{
    public interface ICartRepository
    {
        Task<CartDto> GetCartByUserId(string userId);
        Task<CartDto> CreateUpdateCart(CartDto cartDto);
        Task<bool> RemoveFromCart(int cartDetailsId);
        Task<bool> ClearCart(string userId);

        Task<bool> ApplyCoupon(string userId, string coupon);
        Task<bool> RemoveCoupon(string userId);
    }
}
