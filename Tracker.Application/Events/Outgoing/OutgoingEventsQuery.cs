using MediatR;
using Tracker.Application.Abstractions;

namespace Tracker.Application.Events.Outgoing
{
    public sealed record OutgoingEventsQuery : IRequest<OutgoingEventsResult>
    {
        public int? PageNumber { get; init; }
        public int? PageSize { get; init; }
    };
}
