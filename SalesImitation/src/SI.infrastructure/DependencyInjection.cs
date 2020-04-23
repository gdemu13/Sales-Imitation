using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using SI.Domain.Abstractions.Repositories;
using SI.Infrastructure.DAL.Repository;

namespace SI.Infrastructure {
    public static class DependencyInjection {
        public static IServiceCollection AddInfrastructure (this IServiceCollection services) {
            services.AddSingleton<IPlayerRepository, PlayerRepository> ();
            services.AddSingleton<ISuperBonusRepository, SuperBonusRepository> ();
            services.AddSingleton<ICategoryRepository, CategoryRepository> ();
            services.AddSingleton<IPartnerRepository, PartnerRepository> ();
            services.AddSingleton<IProductRepository, ProductRepository> ();
            services.AddSingleton<IMissionRepository, MissionRepository> ();
            return services;
        }
    }
}