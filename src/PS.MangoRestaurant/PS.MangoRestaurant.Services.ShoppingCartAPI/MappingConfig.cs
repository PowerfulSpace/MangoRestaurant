using AutoMapper;
using PS.MangoRestaurant.Services.ShoppingCartAPI.Models;
using PS.MangoRestaurant.Services.ShoppingCartAPI.Models.Dto;

namespace PS.MangoRestaurant.Services.ShoppingCartAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {

                //config.CreateMap<Product, ProductDto>().ReverseMap();
                //config.CreateMap<Cart, CartDto>().ReverseMap();
                //config.CreateMap<CartHeader, CartHeaderDto>().ReverseMap();
                //config.CreateMap<CartDetails, CartDetailsDto>().ReverseMap();

                config.CreateMap<Product, ProductDto>();
                config.CreateMap<Cart, CartDto>();
                config.CreateMap<CartHeader, CartHeaderDto>();
                config.CreateMap<CartDetails, CartDetailsDto>();

                config.CreateMap<ProductDto, Product>();
                config.CreateMap<CartDto, Cart>();
                config.CreateMap<CartHeaderDto, CartHeader>();
                config.CreateMap<CartDetailsDto, CartDetails>();
            });

            return mappingConfig;
        }
    }
}
