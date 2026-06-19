using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tracker.Application.Events.Incoming;

namespace Tracker.Api.Controllers
{
    [ApiController]
    [Route("api/incoming-events")]
    public class IncomingEventsController(ISender sender) : ControllerBase
    {
        private readonly ISender _sender = sender;

        [HttpPost]
        public async Task<IActionResult> Post(IncomingEventCommand command, CancellationToken cancellationToken)
        {
            var result = await _sender.Send(command, cancellationToken);
            return Ok(result);
        }
    }
}
