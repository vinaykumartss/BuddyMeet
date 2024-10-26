using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace App.EnglishBuddy.API.Controllers
{
    [ApiController]
    [Route("random")]
    
    public class RandomCallsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RandomCallsController(IMediator mediator)
        {
            _mediator = mediator;
        }


       

       

      
    }
}