using MediatR;
using Tracker.Application.Events.Repository;

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
            // TODO: use case orchestration here

            return new IncomingEventResult
            {
                Success = true,
                Message = "Event processed successfully"
            };
        }
    }
}
