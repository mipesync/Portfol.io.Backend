using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Portfol.io.Application.Interfaces;
using System.Reflection;

namespace Portfol.io.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
