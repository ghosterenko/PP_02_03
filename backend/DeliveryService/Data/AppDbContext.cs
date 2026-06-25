using DeliveryService.Models;
using Microsoft.EntityFrameworkCore;

namespace DeliveryService.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<CityDelivery> Cities { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=../delivery.db");
        }
    }
}
