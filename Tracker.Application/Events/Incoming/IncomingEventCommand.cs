using System.Text.Json.Serialization;
using MediatR;
using Tracker.Domain.Events;

namespace Tracker.Application.Events.Incoming
{
    public sealed record IncomingEventCommand : IRequest<IncomingEventResult>
    {
        [JsonPropertyName("event_name")]
        public required string EventName { get; init; }

        [JsonPropertyName("event_timestamp")]
        public required DateTime EventTimestamp { get; init; }

        [JsonPropertyName("event_source")]
        public required string EventSource { get; init; }

        public Event IntoEvent() => new(EventName, EventTimestamp, EventSource);
    }

}
