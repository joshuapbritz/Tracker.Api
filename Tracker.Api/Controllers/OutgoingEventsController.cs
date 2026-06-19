using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tracker.Application.Events.Outgoing;

namespace Tracker.Api.Controllers
{
    [ApiController]
    [Route("api/outgoing-events")]
    public class OutgoingEventsController(ISender sender) : ControllerBase
    {
        private readonly ISender _sender = sender;

        [HttpGet]
        public async Task<IActionResult> GetAllEvents(CancellationToken cancellationToken)
        {
            var result = await _sender.Send(new OutgoingEventsQuery(), cancellationToken);
            return Ok(result.EventsList);
        }
    }
}
