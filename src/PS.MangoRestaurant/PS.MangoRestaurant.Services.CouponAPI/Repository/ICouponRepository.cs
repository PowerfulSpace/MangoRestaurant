using PS.MangoRestaurant.Services.CouponAPI.Models.Dto;

namespace PS.MangoRestaurant.Services.CouponAPI.Repository
{
    public interface ICouponRepository
    {
        Task<CouponDto> GetCouponByCode(string couponCode);
    }
}
