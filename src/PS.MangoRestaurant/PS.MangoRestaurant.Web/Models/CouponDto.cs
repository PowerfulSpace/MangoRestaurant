﻿namespace PS.MangoRestaurant.Web.Models
{
    public class CouponDto
    {
        public int CouponId { get; set; }
        public string CouponCode { get; set; } = string.Empty;
        public double DiscountAmount { get; set; }
    }
}
