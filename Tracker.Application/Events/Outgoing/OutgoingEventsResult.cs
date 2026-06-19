using Tracker.Domain.Events;

namespace Tracker.Application.Events.Outgoing
{
    public sealed record OutgoingEventItem
    {
        public required Guid Id { get; init; }
        public required string EventName { get; init; }
        public required DateTime EventTimestamp { get; init; }
        public required string EventSource { get; init; }
    }

    public sealed record OutgoingEventsResult
    {
        public required IReadOnlyList<OutgoingEventItem> EventsList { get; init; }
    }
}
