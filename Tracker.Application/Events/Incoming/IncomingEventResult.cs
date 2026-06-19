namespace Tracker.Application.Events.Incoming
{
    public sealed record IncomingEventResult
    {
        public bool Success { get; init; }
        public required string Message { get; init; }
    }
}
