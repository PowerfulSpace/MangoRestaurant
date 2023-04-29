using System.ComponentModel.DataAnnotations;

namespace PS.MangoRestaurant.Services.CouponAPI.Models
{
    public class Coupon
    {
        [Key]
        public int CouponId { get; set; }
        public string CouponCode { get; set; } = string.Empty;
        public double DiscountAmount { get; set; }
    }
}
