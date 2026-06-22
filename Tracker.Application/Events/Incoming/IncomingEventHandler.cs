using MediatR;
using Tracker.Domain.Entities.Events;
using Tracker.Domain.Abstractions;

namespace Tracker.Application.Events.Incoming
{

    public sealed class IncomingEventHandler(IEventsRepository eventsRepository)
                : IRequestHandler<IncomingEventCommand, IncomingEventResult>
    {
        private readonly IEventsRepository _eventsRepository = eventsRepository;

        public async Task<IncomingEventResult> Handle(
            IncomingEventCommand command,
            CancellationToken cancellationToken)
        {
            TrackerEvent incomingEvent = command.IntoEvent();
            await _eventsRepository.SaveAsync(incomingEvent, cancellationToken);

            return new IncomingEventResult
            {
                Success = true,
                Message = "Event processed successfully"
            };
        }
    }
}
