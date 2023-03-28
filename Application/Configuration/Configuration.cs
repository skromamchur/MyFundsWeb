using Application.Handlers.Core;
using Application.Handlers.Interfaces;
using Domain.Configuration;
using Infrastructure.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Configuration
{
    public static class Configuration
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfigurationRoot configuration)
        {
            return services
                .AddDomain()
                .AddInfrastructure(configuration)
                .AddSingleton<IApplicationUserHandler, ApplicationUserHandler>();
        }
    }
}
