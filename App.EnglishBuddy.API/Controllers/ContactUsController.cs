using App.EnglishBuddy.Application.Features.UserFeatures.AllContactUs;
using App.EnglishBuddy.Application.Features.UserFeatures.ContactUs;
using App.EnglishBuddy.Application.Features.UserFeatures.OtpTemplate;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace App.EnglishBuddy.API.Controllers
{
    [ApiController]
    [Route("contact")]
    public class ContactController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ContactController(IMediator mediator)
        {
            _mediator = mediator;
        }

        
        [HttpPost("create")]
        public async Task<ActionResult<ContactUsResponse>> Create(ContactUsRequest request,
            CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }

        [HttpPost("All")]
        public async Task<ActionResult<ContactUsResponse>> All(AllContactUsRequest request,
            CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }

    }
}