using App.EnglishBuddy.Application.Features.UserFeatures.CreateUser;
using App.EnglishBuddy.Application.Features.UserFeatures.GetAllOnlineUser;
using App.EnglishBuddy.Application.Features.UserFeatures.GetUser;
using App.EnglishBuddy.Application.Features.UserFeatures.OnlineUsers;
using App.EnglishBuddy.Application.Features.UserFeatures.Password;
using App.EnglishBuddy.Application.Features.UserFeatures.UsersImages;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace App.EnglishBuddy.API.Controllers
{
    [ApiController]
    [Route("user")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

       

        [HttpPost("create")]
        public async Task<ActionResult<CreateUserResponse>> Create(CreateUserRequest request,
            CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CreateUserResponse>> Get(Guid id,
            CancellationToken cancellationToken)
        {
            GetUserRequest request = new GetUserRequest()
            {
                Id = id
            };
            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }

        [HttpPost("/upload/{userId}")]
        public async Task<ActionResult<CreateUserResponse>> Upload(UsersImagesRequest file, Guid userId,
            CancellationToken cancellationToken)
        {

            var response = await _mediator.Send(file, cancellationToken);
            return Ok(response);
        }

       
        [HttpPut("update-password")]
        public async Task<ActionResult<PasswordResponse>> SetPassword(PasswordRequest request,
          CancellationToken cancellationToken)
        {

            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }



      
        [HttpPost("all-online")]
        public async Task<ActionResult<GetAllOnlineResponse>> GetAllOnline(GetAllOnlineRequest request,
          CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }


        [HttpPut("online-status")]
        public async Task<ActionResult<OnlineUserStatusResponse>> OnlineStatus(OnlineUserStatusRequest request,
          CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }
    }
}