namespace Tracker.Domain.Events
{
    public sealed record Event
    {
        public Guid Id { get; init; }
        public string EventName { get; init; }
        public DateTime EventTimestamp { get; init; }
        public DateTime CreatedAt { get; init; }
        public string EventSource { get; init; }

        public Event(string eventName, DateTime eventTimestamp, string eventSource)
        {
            if (string.IsNullOrWhiteSpace(eventName))
                throw new ArgumentException("Event name is required.", nameof(eventName));

            if (string.IsNullOrWhiteSpace(eventSource))
                throw new ArgumentException("Event source is required.", nameof(eventSource));

            Id = Guid.NewGuid();
            EventName = eventName;
            EventTimestamp = eventTimestamp;
            EventSource = eventSource;
            CreatedAt = DateTime.UtcNow;
        }
    }
}
