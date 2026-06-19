namespace Tracker.Infrastructure.Persistence
{
    public sealed class InMemoryEventsRepository : IEventsRepository
    {
        private List<Event> _events = new List<Event>();

        public async Task SaveAsync(Event incomingEvent)
        {
            _events.Add(incomingEvent);
        }
    }
}
