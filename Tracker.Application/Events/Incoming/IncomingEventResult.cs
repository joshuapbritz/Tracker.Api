namespace Tracker.Application.Events.Incoming
{
    public sealed record IncomingEventResult
    {
        public bool Success { get; init; }
        public string Message { get; init; }
    }
}
