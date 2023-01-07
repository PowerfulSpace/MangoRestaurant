using AutoMapper;
using PS.MangoRestaurant.Services.ProductAPI.Models;
using PS.MangoRestaurant.Services.ProductAPI.Models.Dto;

namespace PS.MangoRestaurant.Services.ProductAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ProductDto, Product>();
                config.CreateMap<Product, ProductDto>();
            });

            return mappingConfig;
        }
    }
}
