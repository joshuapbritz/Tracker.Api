using Tracker.Domain.Events;

namespace Tracker.Application.Events.Outgoing
{
    public sealed record OutgoingEventsResult
    {
        public required List<Event> EventsList { get; init; }
    }
}
