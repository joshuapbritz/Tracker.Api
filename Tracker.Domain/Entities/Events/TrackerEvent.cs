namespace Tracker.Domain.Entities.Events
{
    public sealed class TrackerEvent
    {
        public Guid Id { get; private init; }
        public string EventName { get; private init; }
        public DateTime EventTimestamp { get; private init; }
        public DateTime CreatedAt { get; private init; }
        public string EventSource { get; private init; }

        public TrackerEvent(string eventName, DateTime eventTimestamp, string eventSource)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(eventName);
            ArgumentException.ThrowIfNullOrWhiteSpace(eventSource);

            Id = Guid.NewGuid();
            EventName = eventName;
            EventTimestamp = eventTimestamp;
            EventSource = eventSource;
            CreatedAt = DateTime.UtcNow;
        }
    }
}
