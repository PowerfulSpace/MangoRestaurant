using Microsoft.AspNetCore.Mvc;
using PS.MangoRestaurant.Services.CouponAPI.Models.Dto;
using PS.MangoRestaurant.Services.CouponAPI.Repository;

namespace PS.MangoRestaurant.Services.CouponAPI.Controllers
{
    [Route("api/coupon")]
    public class CouponAPIController : ControllerBase
    {

        protected ResponseDto _response;
        private readonly ICouponRepository _couponRepository;

        public CouponAPIController(ICouponRepository couponRepository)
        {
            _couponRepository = couponRepository;
            this._response = new ResponseDto();
        }

        [HttpGet("{code}")]
        public async Task<object> GetDiscountForCode(string code)
        {
            try
            {
                var couponDto = _couponRepository.GetCouponByCode(code);
                _response.Result = couponDto;
            }
            catch (Exception e)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { e.ToString() };
            }
            return _response;
        }
    }
}
