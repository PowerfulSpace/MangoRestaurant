using Microsoft.AspNetCore.Mvc;
using PS.MangoRestaurant.MessageBus;
using PS.MangoRestaurant.Services.ShoppingCartAPI.Messages;
using PS.MangoRestaurant.Services.ShoppingCartAPI.Models.Dto;
using PS.MangoRestaurant.Services.ShoppingCartAPI.Repository;

namespace PS.MangoRestaurant.Services.ShoppingCartAPI.Controllers
{
    [Route("api/cart")]
    public class CartAPIController : ControllerBase
    {

        protected ResponseDto _response;
        private readonly ICartRepository _cartRepository;
        private readonly ICouponRepository _couponRepository;
        private readonly IMessageBus _messageBus;

        public CartAPIController(ICartRepository cartRepository, IMessageBus messageBus, ICouponRepository couponRepository)
        {
            _cartRepository = cartRepository;
            _messageBus = messageBus;
            _couponRepository = couponRepository;

            this._response = new ResponseDto();
        }

        [HttpGet("GetCart/{userId}")]
        public async Task<object> GetCart(string userId)
        {
            try
            {
                var cartDto = await _cartRepository.GetCartByUserId(userId);
                _response.Result = cartDto;
            }
            catch (Exception e)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { e.ToString() };
            }
            return _response;
        }

        [HttpPost("AddCart")]
        public async Task<object> AddCart([FromBody] CartDto cartDto)
        {
            try
            {
                var cartD = await _cartRepository.CreateUpdateCart(cartDto);
                _response.Result = cartD;
            }
            catch (Exception e)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { e.ToString() };
            }
            return _response;
        }

        [HttpPost("UpdateCart")]
        public async Task<object> UpdateCart([FromBody] CartDto cartDto)
        {
            try
            {
                var cartD = await _cartRepository.CreateUpdateCart(cartDto);
                _response.Result = cartD;
            }
            catch (Exception e)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { e.ToString() };
            }
            return _response;
        }

        [HttpPost("RemoveCart")]
        public async Task<object> RemoveCart([FromBody]int cartId)
        {
            try
            {
                var isSuccess = await _cartRepository.RemoveFromCart(cartId);
                _response.Result = isSuccess;
            }
            catch (Exception e)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { e.ToString() };
            }
            return _response;
        }

        [HttpPost("ClearCart")]
        public async Task<object> ClearCart([FromBody] string userId)
        {
            try
            {
                var isSuccess = await _cartRepository.ClearCart(userId);
                _response.Result = isSuccess;
            }
            catch (Exception e)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { e.ToString() };
            }
            return _response;
        }



        [HttpPost("ApplyCoupon")]
        public async Task<object> ApplyCoupon([FromBody] CartDto cartDto)
        {
            try
            {
                var isSuccess = await _cartRepository.ApplyCoupon(cartDto.CartHeader.UserId, cartDto.CartHeader.CouponCode);
                _response.Result = isSuccess;
            }
            catch (Exception e)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { e.ToString() };
            }
            return _response;
        }

        [HttpPost("RemoveCoupon")]
        public async Task<object> RemoveCoupon([FromBody] string userId)
        {
            try
            {
                var isSuccess = await _cartRepository.RemoveCoupon(userId);
                _response.Result = isSuccess;
            }
            catch (Exception e)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { e.ToString() };
            }
            return _response;
        }

        [HttpPost("Checkout")]
        public async Task<object> Checkout([FromBody] CheckoutHeaderDto checkoutHeader)
        {
            try
            {
                CartDto cartDto = await _cartRepository.GetCartByUserId(checkoutHeader.UserId);
                if(cartDto == null) { return BadRequest(); }
                checkoutHeader.CartDetails = cartDto.CartDetails;

                if (!string.IsNullOrEmpty(checkoutHeader.CouponCode))
                {
                    CouponDto coupon = await _couponRepository.GetCoupon(checkoutHeader.CouponCode);
                    if(checkoutHeader.DiscountTotal != coupon.DiscountAmount)
                    {
                        _response.IsSuccess=false;
                        _response.ErrorMessages = new List<string>() { "Coupon Price has changed, please confirm" };
                        _response.DisplayMessage = "Coupon Price has changed, please confirm";
                        return _response;
                    }
                }
                //Добавить логику для сообщений заказа
            }
            catch (Exception e)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { e.ToString() };
            }
            return _response;
        }

        #region Azure test

        [HttpPost("AzureCheckout")]
        public async Task<object> AzureCheckout([FromBody] CheckoutHeaderDto checkoutHeader)
        {
            try
            {
                CartDto cartDto = await _cartRepository.GetCartByUserId(checkoutHeader.UserId);
                if (cartDto == null) { return BadRequest(); }
                checkoutHeader.CartDetails = cartDto.CartDetails;

                await _messageBus.PublishMessage(checkoutHeader, "checkoutmessagetopic");
            }
            catch (Exception e)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { e.ToString() };
            }
            return _response;
        }

        #endregion

    }
}
