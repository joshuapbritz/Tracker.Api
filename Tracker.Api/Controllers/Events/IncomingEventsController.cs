using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tracker.Api.Contracts.Requests;
using Tracker.Api.Contracts.Responses;

namespace Tracker.Api.Controllers.Events
{
    [ApiController]
    [Route("api/incoming-events")]
    public class IncomingEventsController(ISender sender) : ControllerBase
    {
        private readonly ISender _sender = sender;

        [HttpPost]
        public async Task<IActionResult> PostNewEvent(IncomingEventsRequest request, CancellationToken cancellationToken)
        {
            var command = request.IntoCommand();
            var result = await _sender.Send(command, cancellationToken);

            var response = IncomingEventsResponse.FromResult(result);
            return Ok(response);
        }
    }
}
