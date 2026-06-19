namespace Tracker.Domain.Events
{
    public sealed record Event
    {
        public string EventName { get; init; }
        public DateTime EventTimestamp { get; init; }
        public string EventSource { get; init; }

        public Event(string eventName, DateTime eventTimestamp, string eventSource)
        {
            if (string.IsNullOrWhiteSpace(eventName))
                throw new ArgumentException("Event name is required.", nameof(eventName));

            if (string.IsNullOrWhiteSpace(eventSource))
                throw new ArgumentException("Event source is required.", nameof(eventSource));

            EventName = eventName;
            EventTimestamp = eventTimestamp;
            EventSource = eventSource;
        }
    }
}
