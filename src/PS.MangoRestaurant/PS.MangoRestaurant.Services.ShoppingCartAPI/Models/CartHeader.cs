﻿using System.ComponentModel.DataAnnotations;

namespace PS.MangoRestaurant.Services.ShoppingCartAPI.Models
{
    public class CartHeader
    {
        [Key]
        public int CartHeaderId { get; set; }
        public string UserId { get; set; } = string.Empty;
        public string CouponCode { get; set; } = string.Empty;
    }
}
