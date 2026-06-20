using MediatR;
using Tracker.Domain.Events;
using Tracker.Application.Abstractions;

namespace Tracker.Application.Events.Outgoing
{
    public sealed class OutgoingEventsHandler(ISettingsProvider settings, IEventsRepository eventsRepository)
                : IRequestHandler<OutgoingEventsQuery, OutgoingEventsResult>
    {
        private readonly IEventsRepository _eventsRepository = eventsRepository;
        private readonly ISettingsProvider _settings = settings;

        public async Task<OutgoingEventsResult> Handle(
            OutgoingEventsQuery command,
            CancellationToken cancellationToken)
        {
            int pageSize = command.PageSize ?? _settings.DefaultQueryOptions.PageSize;
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
