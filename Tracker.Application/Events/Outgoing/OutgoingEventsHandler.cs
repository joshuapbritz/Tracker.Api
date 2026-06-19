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
            List<Event> events = await _eventsRepository.GetAsync(cancellationToken);

            return new OutgoingEventsResult
            {
                EventsList = events
            };
        }
    }
}
