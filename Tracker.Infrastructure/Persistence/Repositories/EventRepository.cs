using Tracker.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Tracker.Domain.Events;

namespace Tracker.Infrastructure.Persistence.Repositories
{
    public class EventsRepository(TrackerDbContext context) : IEventsRepository
    {
        private readonly TrackerDbContext _context = context;

        public Task<List<Event>> GetAsync(CancellationToken cancellationToken)
        {
            return _context.Events.OrderByDescending(e => e.EventTimestamp).Skip(0).Take(20).ToListAsync(cancellationToken);
        }

        public async Task SaveAsync(Event incomingEvent, CancellationToken cancellationToken)
        {
            await _context.Events.AddAsync(incomingEvent, cancellationToken);

            // TODO: learn more about error handling here
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
