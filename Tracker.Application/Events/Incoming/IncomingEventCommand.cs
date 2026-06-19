using MediatR;

namespace Tracker.Application.Events.Incoming
{
    public sealed record IncomingEventCommand : IRequest<IncomingEventResult>
    {
        public required string EventName { get; init; }
        public required DateTime EventTimestamp { get; init; }
        public required string EventSource { get; init; }
    }
}
