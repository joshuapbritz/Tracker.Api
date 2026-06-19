using Microsoft.EntityFrameworkCore;
using Tracker.Domain.Events;

namespace Tracker.Infrastructure.Persistence
{
    public sealed class TrackerDbContext(DbContextOptions<TrackerDbContext> options) : DbContext(options)
    {
        internal DbSet<TrackerEvent> Events => Set<TrackerEvent>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TrackerDbContext).Assembly);
        }
    }
}
