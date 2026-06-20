using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tracker.Application.Abstractions;
using Tracker.Infrastructure.Persistence;
using Tracker.Infrastructure.Persistence.Repositories;
using Tracker.Infrastructure.Settings;

namespace Tracker.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddSettings();
            services.AddPersistence(configuration);
            return services;
        }

        private static IServiceCollection AddSettings(this IServiceCollection services)
        {
            services.AddSingleton<ISettingsProvider, SettingsProvider>();
            return services;
        }

        private static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("TrackerDb");

            if (string.IsNullOrWhiteSpace(connectionString))
                throw new InvalidOperationException("Connection string 'TrackerDb' is required.");

            services.AddDbContext<TrackerDbContext>(options =>
                options.UseNpgsql(connectionString));

            services.AddScoped<IEventsRepository, EventsRepository>();

            return services;
        }
    }
}
