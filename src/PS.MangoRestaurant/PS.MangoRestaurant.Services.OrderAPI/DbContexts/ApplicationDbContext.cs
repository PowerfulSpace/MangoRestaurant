using Microsoft.EntityFrameworkCore;
using PS.MangoRestaurant.Services.OrderAPI.Models;

namespace PS.MangoRestaurant.Services.OrderAPI.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<OrderHeader> orderHeaders { get; set; }
    }
}
