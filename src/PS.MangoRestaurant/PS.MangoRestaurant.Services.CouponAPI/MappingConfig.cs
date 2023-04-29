using AutoMapper;
using PS.MangoRestaurant.Services.CouponAPI.Models;
using PS.MangoRestaurant.Services.CouponAPI.Models.Dto;

namespace PS.MangoRestaurant.Services.CouponAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<Coupon, CouponDto>().ReverseMap();
            });

            return mappingConfig;
        }
    }
}
