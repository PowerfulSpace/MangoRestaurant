using PS.MangoRestaurant.Services.ShoppingCartAPI.Models.Dto;

namespace PS.MangoRestaurant.Services.ShoppingCartAPI.Repository
{
    public interface ICouponRepository
    {
        Task<CouponDto> GetCoupon(string couponName);
    }
}
