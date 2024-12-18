using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace BirlikteMiniDemo.Persistence
{
    public class BirlikteMiniDemoContextFactory : IDesignTimeDbContextFactory<BirlikteMiniDemoContext>
    {
        public BirlikteMiniDemoContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../BirlikteMiniDemo.Api"))
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            var optionsBuilder = new DbContextOptionsBuilder<BirlikteMiniDemoContext>();
            optionsBuilder.UseNpgsql(connectionString);

            return new BirlikteMiniDemoContext(optionsBuilder.Options);
        }
    }
}
