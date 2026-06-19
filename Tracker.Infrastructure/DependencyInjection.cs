using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tracker.Domain.Interfaces;
using Tracker.Infrastructure.Persistence;
using Tracker.Infrastructure.Persistence.Repositories;

namespace Tracker.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddPersistence(configuration);
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
