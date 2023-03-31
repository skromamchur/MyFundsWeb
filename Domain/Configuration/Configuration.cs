using Domain.Repositories;
using Domain.Services.Core;
using Domain.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Domain.Configuration
{
    public static class Configuration
    {
        public static IServiceCollection AddDomain(this IServiceCollection services) {
            return services
                .AddSingleton<IUserService, UserService>()
                .AddSingleton<ITransactionService, TransactionService>();
        }
    }
}
