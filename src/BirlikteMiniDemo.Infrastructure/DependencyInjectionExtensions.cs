using BirlikteMiniDemo.Domain.Services;
using BirlikteMiniDemo.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BirlikteMiniDemo.Infrastructure
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IBasketService, BasketService>();
            services.AddScoped<IBasketItemService, BasketItemService>();

            return services;
        }
    }
}
