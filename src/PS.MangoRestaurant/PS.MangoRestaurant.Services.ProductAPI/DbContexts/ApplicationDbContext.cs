using Microsoft.EntityFrameworkCore;
using PS.MangoRestaurant.Services.ProductAPI.Models;

namespace PS.MangoRestaurant.Services.ProductAPI.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; } = null!;
    }
}
