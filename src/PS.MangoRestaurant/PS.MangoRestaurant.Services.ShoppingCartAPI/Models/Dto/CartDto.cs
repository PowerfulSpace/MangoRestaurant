﻿namespace PS.MangoRestaurant.Services.ShoppingCartAPI.Models.Dto
{
    public class CartDto
    {
        public CartHeaderDto CartHeader { get; set; } = null!;
        public IEnumerable<CartDetailsDto> CartDetails { get; set; } = null!;
    }
}
