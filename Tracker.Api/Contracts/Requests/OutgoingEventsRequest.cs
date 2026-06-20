using Microsoft.AspNetCore.Mvc;

namespace Tracker.Api.Contracts.Requests
{
    public sealed record OutgoingEventsRequest
    {
        [FromQuery(Name = "page_number")]
        public int? PageNumber { get; init; }
        [FromQuery(Name = "page_size")]
        public int? PageSize { get; init; }
    }
}
