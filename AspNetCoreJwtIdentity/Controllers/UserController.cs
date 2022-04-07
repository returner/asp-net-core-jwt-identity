using BusinessLayer.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedModel.DataTransfers;
using SharedModel.Request;

namespace AspNetCoreJwtIdentity.Controllers
{
    [ApiController]
    [Route("controller")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        
        public UserController(IMediator mediator) => _mediator = mediator;

        [HttpPost]
        public async Task<IActionResult> CreateUserAsync(UserRequest request)
        {
            try
            {
                var result = await _mediator.Send(new CreateUserCommand(new UserDtoRequest(request.Username, request.Password)));
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
