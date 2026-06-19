using Tracker.Application.Events.Repository;
using Tracker.Domain.Events;

namespace Tracker.Infrastructure.Persistence
{
    public sealed class InMemoryEventsRepository : IEventsRepository
    {
        private List<Event> _events = new List<Event>();

        public async Task SaveAsync(Event incomingEvent, CancellationToken cancellationToken)
        {
            _events.Add(incomingEvent);
        }
    }
}
