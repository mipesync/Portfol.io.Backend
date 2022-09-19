using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Portfol.io.Application.Interfaces;
using Portfol.io.Persistence.Services;

namespace Portfol.io.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<PortfolioDbContext>(option => option.UseNpgsql(connectionString));
            services.AddScoped<IPortfolioDbContext>(provider => provider.GetService<PortfolioDbContext>()!);
            services.AddTransient<IConfigSectionGetter, ConfigSectionGetter>();
            services.AddTransient<IImageUploader, ImageUploader>();

            return services;
        }
    }
}
