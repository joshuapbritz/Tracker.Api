using Microsoft.EntityFrameworkCore;
using Tracker.Domain.Events;

namespace Tracker.Infrastructure.Persistence
{
    public sealed class TrackerDbContext(DbContextOptions<TrackerDbContext> options) : DbContext(options)
    {
        internal DbSet<Event> Events => Set<Event>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TrackerDbContext).Assembly);
        }
    }
}
