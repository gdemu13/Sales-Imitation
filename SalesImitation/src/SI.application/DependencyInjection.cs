using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SI.Application.Translations;

namespace SI.Application {
    public static class DependencyInjection {
        public static IServiceCollection AddApplication (this IServiceCollection services) {
            services.AddMediatR (Assembly.GetExecutingAssembly ());
            services.AddSingleton<ITranslationsService, TranslationsService>();
            return services;
        }
    }
}