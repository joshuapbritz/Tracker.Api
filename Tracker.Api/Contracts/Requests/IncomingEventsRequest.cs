using System.Text.Json.Serialization;
using Tracker.Application.Events.Incoming;

namespace Tracker.Api.Contracts.Requests
{
    public sealed record IncomingEventsRequest
    {
        [JsonPropertyName("event_name")]
        public required string EventName { get; init; }

        [JsonPropertyName("event_timestamp")]
        public required DateTime EventTimestamp { get; init; }

        [JsonPropertyName("event_source")]
        public required string EventSource { get; init; }

        public IncomingEventCommand IntoCommand()
        {
            return new IncomingEventCommand
            {
                EventName = EventName,
                EventSource = EventSource,
                EventTimestamp = EventTimestamp
            };
        }
    }
}
