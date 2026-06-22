using Tracker.Domain.Entities.Events;

namespace Tracker.Domain.Abstractions
{
    public interface IEventsRepository
    {
        Task SaveAsync(TrackerEvent incomingEvent, CancellationToken cancellationToken);
        Task<IReadOnlyList<TrackerEvent>> GetLatestAsync(int skip, int take, CancellationToken cancellationToken);
    }
}
