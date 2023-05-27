using Domain.Repositories;
using Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Configuration
{
    public static class Configuration
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfigurationRoot configuration)
        {
            return services
                   .AddSingleton<IUserRepository>(Provider => new UserRepository(configuration.GetSection("ConnectionString").Value!))
                   .AddSingleton<ITransactionRepository>(Provider => new TransactionRepository(configuration.GetSection("ConnectionString").Value!))
                   .AddSingleton<IGoalRepository>(Provider => new GoalRepository(configuration.GetSection("ConnectionString").Value!));
        }
    }
}
