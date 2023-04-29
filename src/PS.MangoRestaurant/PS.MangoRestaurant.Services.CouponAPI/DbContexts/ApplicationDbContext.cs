using Microsoft.EntityFrameworkCore;
using PS.MangoRestaurant.Services.CouponAPI.Models;

namespace PS.MangoRestaurant.Services.CouponAPI.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Coupon> Coupons { get; set; }
    }
}
