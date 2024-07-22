using Infrastructure.Constans;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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
        [AllowAnonymous]
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
        [AllowAnonymous]
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
        [Authorize(Roles = UserRolesConstant.AdminOrStaff)]
        [HttpPost]
        public async Task<IActionResult> GetUser([FromForm] GetUserCommand command)
        {
            var result = await _mediator.Send(command);
            if(!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> UpdateProfile([FromForm] UpdateProfileCommand command)
        {
            var result = await _mediator.Send(command);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> UpdatePassword([FromForm] UpdatePasswordCommand command)
        {
            var result = await _mediator.Send(command);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [Authorize(Roles = UserRolesConstant.AdminOrStaff)]
        [HttpPost]
        public async Task<IActionResult> GetAllUser([FromForm] GetAllUserCommand command)
        {
            var result = await _mediator.Send(command);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [Authorize(Roles = UserRolesConstant.Admin)]
        [HttpPost]
        public async Task<IActionResult> LockAccount([FromForm]LockAccountCommand command)
        {
            var result = await _mediator.Send(command);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [Authorize(Roles = UserRolesConstant.Admin)]
        [HttpPost]
        public async Task<IActionResult> createstaffaccount([FromForm] CreateAccountStaffCommand command)
        {
            var result = await _mediator.Send(command);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
