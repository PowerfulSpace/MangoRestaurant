﻿using PS.MangoRestaurant.MessageBus;
using PS.MangoRestaurant.Services.ShoppingCartAPI.Models.Dto;

namespace PS.MangoRestaurant.Services.ShoppingCartAPI.Messages
{
    public class CheckoutHeaderDto : BaseMessage
    {
        public int CartHeaderId { get; set; }
        public string UserId { get; set; } = string.Empty;
        public string CouponCode { get; set; } = string.Empty;
        public double OrderTotal { get; set; }
        public double DiscountTotal { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime PickupDateTime { get; set; }
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string CardNumber { get; set; } = string.Empty;
        public string CVV { get; set; } = string.Empty;
        public string ExpiryMonthYear { get; set; } = string.Empty;
        public int CartTotalItems { get; set; }
        public IEnumerable<CartDetailsDto> CartDetails { get; set; } = null!;
    }
}
