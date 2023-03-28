using Application.Handlers.Core;
using Application.Handlers.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Configuration
{
    public static class Configuration
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            return services.AddSingleton<IApplicationUserHandler, ApplicationUserHandler>();
        }
    }
}
