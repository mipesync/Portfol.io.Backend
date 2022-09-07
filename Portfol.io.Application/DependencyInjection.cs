using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Portfol.io.Application.Common.Behaviors;
using Portfol.io.Application.Common.Mappings;
using System.Reflection;

namespace Portfol.io.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(u => u.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly())));
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssemblies(new[] { Assembly.GetExecutingAssembly() });
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            return services;
        }
    }
}
