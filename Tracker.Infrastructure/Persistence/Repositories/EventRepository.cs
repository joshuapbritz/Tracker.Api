using Tracker.Application.Abstractions;
using Microsoft.EntityFrameworkCore;
using Tracker.Domain.Events;

namespace Tracker.Infrastructure.Persistence.Repositories
{
    public class EventsRepository(TrackerDbContext context) : IEventsRepository
    {
        private readonly TrackerDbContext _context = context;

        public async Task<IReadOnlyList<TrackerEvent>> GetLatestWithPagingAsync(int skip, int take, CancellationToken cancellationToken)
        {
            return await _context.Events.OrderByDescending(e => e.EventTimestamp).Skip(skip).Take(take).ToListAsync(cancellationToken);
        }

        public async Task SaveAsync(TrackerEvent incomingEvent, CancellationToken cancellationToken)
        {
            await _context.Events.AddAsync(incomingEvent, cancellationToken);

            // TODO: learn more about error handling here
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
