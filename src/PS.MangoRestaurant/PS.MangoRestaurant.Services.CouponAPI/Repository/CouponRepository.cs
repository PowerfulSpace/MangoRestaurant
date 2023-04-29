using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PS.MangoRestaurant.Services.CouponAPI.DbContexts;
using PS.MangoRestaurant.Services.CouponAPI.Models;
using PS.MangoRestaurant.Services.CouponAPI.Models.Dto;

namespace PS.MangoRestaurant.Services.CouponAPI.Repository
{
    public class CouponRepository : ICouponRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public CouponRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<CouponDto> GetCouponByCode(string couponCode)
        {
            var couponFromDb = await _db.Coupons.FirstOrDefaultAsync(x => x.CouponCode == couponCode);
            return _mapper.Map<Coupon, CouponDto>(couponFromDb);
        }
    }
}
