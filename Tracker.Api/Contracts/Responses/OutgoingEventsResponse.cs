using System.Text.Json.Serialization;
using Tracker.Application.Events.Outgoing;

namespace Tracker.Api.Contracts.Responses
{
    public sealed record OutgoingEvent
    {
        public required string Id { get; init; }
        [JsonPropertyName("event_name")]
        public required string EventName { get; init; }
        [JsonPropertyName("event_timestamp")]
        public required DateTime EventTimestamp { get; init; }
        [JsonPropertyName("event_source")]
        public required string EventSource { get; init; }
    }

    public sealed record OutgoingEventsResponse
    {
        public required IReadOnlyList<OutgoingEvent> Results { get; init; }

        public static OutgoingEventsResponse FromResult(OutgoingEventsResult result)
        {
            return new OutgoingEventsResponse
            {
                Results = [.. result.EventsList.Select(e => new OutgoingEvent
                {
                    Id = e.Id.ToString(),
                    EventName = e.EventName,
                    EventTimestamp = e.EventTimestamp,
                    EventSource = e.EventSource
                })]
            };
        }
    }
}
