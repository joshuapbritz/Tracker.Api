using Tracker.Domain.Events;

namespace Tracker.Application.Abstractions
{
    public interface IEventsRepository
    {
        Task SaveAsync(Event incomingEvent, CancellationToken cancellationToken);
        Task<List<Event>> GetAsync(CancellationToken cancellationToken);
    }
}
