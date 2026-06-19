using Tracker.Domain.Events;

namespace Tracker.Application.Abstractions
{
    public interface IEventsRepository
    {
        Task SaveAsync(TrackerEvent incomingEvent, CancellationToken cancellationToken);
        Task<IReadOnlyList<TrackerEvent>> GetLatestWithPagingAsync(int skip, int take, CancellationToken cancellationToken);
    }
}
