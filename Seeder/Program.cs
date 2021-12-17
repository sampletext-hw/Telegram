using Microsoft.Extensions.DependencyInjection;
using WebAPI.DataRepository;

namespace Seeder
{
    public static class Program
    {
        private static async Task Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddDbContext<CustomerDbContext>()
                .BuildServiceProvider();

            await new SeedData(serviceProvider).Seed();
            Console.WriteLine("Seeded successfully");
        }
    }
}