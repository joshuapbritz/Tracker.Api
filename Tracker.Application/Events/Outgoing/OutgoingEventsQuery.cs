using MediatR;

namespace Tracker.Application.Events.Outgoing
{
    public sealed record OutgoingEventsQuery : IRequest<OutgoingEventsResult>;
}
