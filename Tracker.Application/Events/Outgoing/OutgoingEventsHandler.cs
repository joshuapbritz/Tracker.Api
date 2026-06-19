using MediatR;
using Tracker.Domain.Events;
using Tracker.Application.Abstractions;

namespace Tracker.Application.Events.Outgoing
{
    public sealed class OutgoingEventsHandler(IEventsRepository eventsRepository)
                : IRequestHandler<OutgoingEventsQuery, OutgoingEventsResult>
    {
        private readonly IEventsRepository _eventsRepository = eventsRepository;

        public async Task<OutgoingEventsResult> Handle(
            OutgoingEventsQuery command,
            CancellationToken cancellationToken)
        {
            // TODO: Skip and take hard-coded for now, but will be updated down the line
            IReadOnlyList<TrackerEvent> events = await _eventsRepository.GetLatestWithPagingAsync(0, 20, cancellationToken);

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
