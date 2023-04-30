﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PS.MangoRestaurant.Services.ShoppingCartAPI.DbContexts;
using PS.MangoRestaurant.Services.ShoppingCartAPI.Models;
using PS.MangoRestaurant.Services.ShoppingCartAPI.Models.Dto;

namespace PS.MangoRestaurant.Services.ShoppingCartAPI.Repository
{
    public class CartRepository : ICartRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public CartRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<CartDto> GetCartByUserId(string userId)
        {
            Cart cart = new Cart()
            {
                CartHeader = await _db.CartHeaders.FirstOrDefaultAsync(u => u.UserId == userId)
            };
            cart.CartDetails = _db.CartDetails.Where(u => u.CartHeaderId == cart.CartHeader.CartHeaderId).Include(u => u.Product);

            return _mapper.Map<CartDto>(cart);
        }

        public async Task<CartDto> CreateUpdateCart(CartDto cartDto)
        {

            var cart = _mapper.Map<CartDto, Cart>(cartDto);
            var prodInDb = await _db.Products.FirstOrDefaultAsync(u => u.ProductId == cart.CartDetails.FirstOrDefault()!.ProductId);
                
            if (prodInDb == null)
            {
                _db.Products.Add(cart.CartDetails.FirstOrDefault()!.Product);
                await _db.SaveChangesAsync();
            }

            var cartHeaderFromDb = await _db.CartHeaders.AsNoTracking().FirstOrDefaultAsync(u => u.UserId == cart.CartHeader.UserId);

            if (cartHeaderFromDb == null)
            {
                _db.CartHeaders.Add(cart.CartHeader);
                await _db.SaveChangesAsync();
                cart.CartDetails.FirstOrDefault()!.CartHeaderId = cart.CartHeader.CartHeaderId;
                cart.CartDetails.FirstOrDefault()!.Product = null!;
                _db.CartDetails.Add(cart.CartDetails.FirstOrDefault()!);
                await _db.SaveChangesAsync();
            }
            else
            {
                var cartDetailsFromDb = await _db.CartDetails.AsNoTracking().FirstOrDefaultAsync(
                    u => u.ProductId == cart.CartDetails.FirstOrDefault()!.ProductId &&
                    u.CartHeaderId == cartHeaderFromDb.CartHeaderId);

                if(cartDetailsFromDb == null)
                {
                    cart.CartDetails.FirstOrDefault()!.CartHeaderId = cartHeaderFromDb.CartHeaderId;
                    cart.CartDetails.FirstOrDefault()!.Product = null!;
                    _db.CartDetails.Add(cart.CartDetails.FirstOrDefault()!);
                    await _db.SaveChangesAsync();
                }
                else
                {
                    cart.CartDetails.FirstOrDefault()!.Product = null!;
                    cart.CartDetails.FirstOrDefault()!.Count += cartDetailsFromDb.Count;
                    cart.CartDetails.FirstOrDefault()!.CartDetailsId = cartDetailsFromDb.CartDetailsId;
                    cart.CartDetails.FirstOrDefault()!.CartHeaderId = cartDetailsFromDb.CartHeaderId;
                    _db.CartDetails.Update(cart.CartDetails.FirstOrDefault()!);
                    await _db.SaveChangesAsync();
                }
            }

            return _mapper.Map<Cart, CartDto>(cart);

        }

        public async Task<bool> RemoveFromCart(int cartDetailsId)
        {
            try
            {
                var cartDetails = await _db.CartDetails.FirstOrDefaultAsync(u => u.CartDetailsId == cartDetailsId);
                int totalCountOfCartItems = _db.CartDetails.Where(u => u.CartHeaderId == cartDetails!.CartHeaderId).Count();

                _db.CartDetails.Remove(cartDetails!);

                if (totalCountOfCartItems == 1)
                {
                    var cartHeaderToRemove = await _db.CartHeaders.FirstOrDefaultAsync(u => u.CartHeaderId == cartDetails!.CartHeaderId);
                    _db.CartHeaders.Remove(cartHeaderToRemove!);
                }
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> ClearCart(string userId)
        {
            var cartHeaderFromDb = await _db.CartHeaders.FirstOrDefaultAsync(u=>u.UserId == userId);

            if (cartHeaderFromDb != null)
            {
                _db.CartDetails.RemoveRange(_db.CartDetails.Where(u => u.CartHeaderId == cartHeaderFromDb.CartHeaderId));
                _db.CartHeaders.Remove(cartHeaderFromDb);
                await _db.SaveChangesAsync();
                return true;
            }
            return false;
        }


        public async Task<bool> ApplyCoupon(string userId, string coupon)
        {
            var cartFromDb = await _db.CartHeaders.FirstOrDefaultAsync(u => u.UserId == userId);
            cartFromDb!.CouponCode = coupon;
            _db.CartHeaders.Update(cartFromDb);
            await _db.SaveChangesAsync();
            return true;
        }
        public async Task<bool> RemoveCoupon(string userId)
        {
            var cartFromDb = await _db.CartHeaders.FirstOrDefaultAsync(u => u.UserId == userId);
            cartFromDb!.CouponCode = "";
            _db.CartHeaders.Update(cartFromDb);
            await _db.SaveChangesAsync();
            return true;
        }

    }
}
