using Microsoft.EntityFrameworkCore;

namespace WebAPI.DataRepository
{
    public class CustomerDbContext : DbContext
    {
        public CustomerDbContext()
        {
        }

        public CustomerDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured) return;

            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=ExampleTesting;Username=postgres;Password=root");

            optionsBuilder.EnableSensitiveDataLogging();
        }

        public DbSet<Customer> Customer { get; set; }

        public DbSet<WeatherForecast> WeatherForecasts { get; set; }
    }
}