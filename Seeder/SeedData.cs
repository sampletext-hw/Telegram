using Microsoft.Extensions.DependencyInjection;
using WebAPI.DataRepository;

namespace Seeder
{
    public class SeedData
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly IServiceScope _serviceScope;

        public SeedData(IServiceProvider provider)
        {
            _serviceScope = provider.CreateScope();
            Context       = _serviceScope.ServiceProvider.GetRequiredService<CustomerDbContext>();
        }

        public async Task Seed()
        {
            await Context.Database.EnsureDeletedAsync();
            await Context.Database.EnsureCreatedAsync();

            Console.WriteLine("Database dropped and recreated");
            
            var rng = new Random();
            await Context.WeatherForecasts.AddRangeAsync(Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date         = DateTime.Now.AddDays(index),
                    TemperatureC = rng.Next(-20, 55),
                    Summary      = Summaries[rng.Next(Summaries.Length)]
                }));
            await Context.SaveChangesAsync();
        }

        ~SeedData()
        {
            _serviceScope.Dispose();
        }

        private CustomerDbContext Context { get; set; }
    }
}