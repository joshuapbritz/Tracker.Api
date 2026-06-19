using Tracker.Application.Events.Incoming;

namespace Tracker.Api.Contracts.Responses
{
    public sealed record IncomingEventsResponse
    {
        public bool Success { get; init; }
        public required string Message { get; init; }

        public static IncomingEventsResponse FromResult(IncomingEventResult result)
        {
            return new IncomingEventsResponse
            {
                Success = result.Success,
                Message = result.Message
            };
        }
    }
}
