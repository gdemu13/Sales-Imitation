using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using SI.Domain.Abstractions.Repositories;
using SI.Infrastructure.DAL.Repository;

namespace SI.Infrastructure {
    public static class DependencyInjection {
        public static IServiceCollection AddInfrastructure (this IServiceCollection services) {
            services.AddSingleton<IPlayerRepository, PlayerRepository> ();
            return services;
        }
    }
}