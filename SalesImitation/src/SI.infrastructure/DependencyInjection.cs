using System.Reflection;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Settings.Configuration;
using SI.Application.Abstractions;
using SI.Application.Contents;
using SI.Application.FAQs;
using SI.Application.Translations;
using SI.Common.Abstractions;
using SI.Domain.Abstractions.Repositories;
using SI.Domain.Services;
using SI.Infrastructure.DAL.Repository;
using SI.Infrastructure.Logging;
using SI.Infrastructure.ServiceClients.Facebook;
using SI.Infrastructure.Storage;

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
            services.AddSingleton<INotificationRepository, NotificationRepository>();
            services.AddSingleton<IContentRepository, ContentRepository>();
            services.AddSingleton<IFAQsRepository, FAQsReposiotry>();
            services.AddScoped<SI.Common.Abstractions.ILogger, SerilogClient>();
            services.AddSingleton<IFacebookService, FacebookService>();
            services.AddSingleton<IFIleService, FileService>();
            services.AddMemoryCache();
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddSingleton<IPlayerService, PlayerService>();

            Serilog.Debugging.SelfLog.Enable(msg => System.Console.WriteLine(msg));

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .CreateLogger();

            ServiceLocator.SetLocatorProvider(services.BuildServiceProvider());

            return services;
        }
    }
}