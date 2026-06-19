using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tracker.Application.Events.Repository;
using Tracker.Infrastructure.Persistence;

namespace Tracker.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("TrackerDb");

            if (string.IsNullOrWhiteSpace(connectionString))
                throw new InvalidOperationException("Connection string 'TrackerDb' is required.");

            services.AddDbContext<TrackerDbContext>(options =>
                options.UseNpgsql(connectionString));

            services.AddScoped<IEventsRepository, EfCoreEventsRepository>();

            return services;
        }
    }
}
