using MediatR;
using Tracker.Application.Events.Repository;
using Tracker.Domain.Events;

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
