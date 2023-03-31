using Microsoft.EntityFrameworkCore;
using PS.MangoRestaurant.Services.ShoppingCartAPI.Models;

namespace PS.MangoRestaurant.Services.ShoppingCartAPI.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<CartHeader> CartHeaders { get; set; } = null!;
        public DbSet<CartDetails> CartDetails { get; set; } = null!;
    }
}
