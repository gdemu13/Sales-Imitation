using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Settings.Configuration;
using SI.Application.Translations;
using SI.Common.Abstractions;
using SI.Domain.Abstractions.Repositories;
using SI.Domain.Services;
using SI.Infrastructure.DAL.Repository;
using SI.Infrastructure.Logging;

namespace SI.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IPlayerRepository, PlayerRepository>();
            services.AddSingleton<ISuperBonusRepository, SuperBonusRepository>();
            services.AddSingleton<ICategoryRepository, CategoryRepository>();
            services.AddSingleton<IPartnerRepository, PartnerRepository>();
            services.AddSingleton<IProductRepository, ProductRepository>();
            services.AddSingleton<IMissionRepository, MissionRepository>();
            services.AddSingleton<IUserRepository, UserRepository>();
            services.AddSingleton<ICurrentMissionRepository, CurrentMissionRepository>();
            services.AddSingleton<ITranslationsRepository, TranslationsRepository>();
            services.AddScoped<SI.Common.Abstractions.ILogger, SerilogClient>();


            services.AddSingleton<IPlayerService, PlayerService>();


            Serilog.Debugging.SelfLog.Enable(msg => System.Console.WriteLine(msg));

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .CreateLogger();

            return services;
        }
    }
}