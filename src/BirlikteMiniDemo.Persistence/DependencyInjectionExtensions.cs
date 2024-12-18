using BirlikteMiniDemo.Domain.Repositories;
using BirlikteMiniDemo.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BirlikteMiniDemo.Persistence
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext <BirlikteMiniDemoContext > (options =>
            {
                options.UseNpgsql(connectionString); 
            });

         
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
