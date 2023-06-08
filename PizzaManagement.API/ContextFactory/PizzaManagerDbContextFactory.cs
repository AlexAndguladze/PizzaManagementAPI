using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using PizzaManagement.Persistence;

namespace PizzaManagement.API.ContextFactory
{
    public class PizzaManagerDbContextFactory : IDesignTimeDbContextFactory<PizzaManagerDbContext>
    {
        public PizzaManagerDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<PizzaManagerDbContext>()
                .UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly("PizzaManagement.Persistence"));

            return new PizzaManagerDbContext(builder.Options);
        }
    }
}
