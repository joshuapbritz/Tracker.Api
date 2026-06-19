using MediatR;
using Tracker.Application.Events.Repository;
using Tracker.Domain.Events;

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
            Event incomingEvent = command.IntoEvent();

            Console.WriteLine(incomingEvent);

            await _eventsRepository.SaveAsync(incomingEvent, cancellationToken);

            return new IncomingEventResult
            {
                Success = true,
                Message = "Event processed successfully"
            };
        }
    }
}
