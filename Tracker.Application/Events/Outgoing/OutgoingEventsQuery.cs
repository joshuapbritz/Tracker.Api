using MediatR;

namespace Tracker.Application.Events.Outgoing
{
    public sealed record OutgoingEventsQuery : IRequest<OutgoingEventsResult>
    {
        public int? PageNumber { get; init; }
        public int? PageSize { get; init; }

        public OutgoingEventsQuery(int? pageNumber, int? pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    };
}
