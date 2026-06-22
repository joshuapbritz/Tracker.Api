using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tracker.Application.Events.Outgoing;
using Tracker.Api.Contracts.Responses;
using Tracker.Api.Contracts.Requests;

namespace Tracker.Api.Controllers.Events
{
    [ApiController]
    [Route("api/outgoing-events")]
    public class OutgoingEventsController(ISender sender) : ControllerBase
    {
        private readonly ISender _sender = sender;

        [HttpGet]
        public async Task<IActionResult> GetAllEvents([FromQuery] OutgoingEventsRequest request, CancellationToken cancellationToken)
        {
            var command = request.IntoCommand();
            var result = await _sender.Send(command, cancellationToken);

            var response = OutgoingEventsResponse.FromResult(result);
            return Ok(response);
        }
    }
}
