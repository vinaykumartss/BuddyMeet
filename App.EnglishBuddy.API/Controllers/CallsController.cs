using App.EnglishBuddy.Application.Features.UserFeatures.CallList;
using App.EnglishBuddy.Application.Features.UserFeatures.CallUsers;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace App.EnglishBuddy.API.Controllers
{
    [ApiController]
    [Route("calls")]
    public class CallsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CallsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("find")]
        public async Task<ActionResult<CallUsersResponse>> FindUser(CallUsersRequest request,
            CancellationToken cancellationToken)
        {

            CallUsersRequest s= new CallUsersRequest();
            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }

       


        [HttpPost("list")]
        public async Task<ActionResult<CallUsersResponse>> List(CallListRequest request,
          CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }
    }
}