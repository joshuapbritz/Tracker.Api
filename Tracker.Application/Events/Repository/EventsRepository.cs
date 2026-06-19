namespace Tracker.Application.Events.Repository
{
    public interface IEventsRepository
    {
        Task SaveAsync(Event incomingEvent, CancellationToken cancellationToken);
    }
}
