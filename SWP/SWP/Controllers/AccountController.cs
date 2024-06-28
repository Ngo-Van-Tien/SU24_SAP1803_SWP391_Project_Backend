using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SWPApi.Application.Account.Commands;

namespace SWPApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ISender _mediator;


        public AccountController(ISender mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> Register([FromForm] RegisterCommand command)
        {
            var response = await _mediator.Send(command);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromForm] LoginCommand command)
        {
            var result = await _mediator.Send(command);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return Unauthorized(result);
        }
    }
}
