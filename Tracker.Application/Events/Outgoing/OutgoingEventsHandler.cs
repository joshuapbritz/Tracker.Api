using MediatR;
using Tracker.Domain.Entities.Events;
using Tracker.Domain.Abstractions;
using Tracker.Domain.Settings;

namespace Tracker.Application.Events.Outgoing
{
    public sealed class OutgoingEventsHandler(DefaultQueryOptions options, IEventsRepository eventsRepository)
                : IRequestHandler<OutgoingEventsQuery, OutgoingEventsResult>
    {
        private readonly IEventsRepository _eventsRepository = eventsRepository;
        private readonly DefaultQueryOptions _options = options;

        public async Task<OutgoingEventsResult> Handle(
            OutgoingEventsQuery command,
            CancellationToken cancellationToken)
        {
            int pageSize = command.PageSize ?? _options.PageSize;
            int pageNumber = command.PageNumber ?? 1;
            int skip = (pageNumber - 1) * pageSize;

            IReadOnlyList<TrackerEvent> events = await _eventsRepository.GetLatestAsync(skip, pageSize, cancellationToken);

            return new OutgoingEventsResult
            {
                EventsList = [.. events.Select(e => new OutgoingEventItem
                {
                    Id = e.Id,
                    EventName = e.EventName,
                    EventTimestamp = e.EventTimestamp,
                    EventSource = e.EventSource
                })]
            };
        }
    }
}
