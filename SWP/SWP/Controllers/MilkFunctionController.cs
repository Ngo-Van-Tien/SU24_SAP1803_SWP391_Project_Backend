using Infrastructure.Constans;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SWPApi.Application.MilkBrand.Commands;
using SWPApi.Application.MilkFunction.Commands;

namespace SWPApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MilkFunctionController : ControllerBase
    {
        private readonly ISender _mediator;

        public MilkFunctionController(ISender mediator)
        {
            _mediator = mediator;
        }
        [Authorize(Roles = UserRolesConstant.AdminOrStaff)]
        [HttpPost]
        public async Task<IActionResult> AddMilkFunction([FromForm] AddMilkFunctionCommand command)
        {
            if (command == null)
            {
                return BadRequest();
            }
            var result = await _mediator.Send(command);
            if (!result.IsSuccess)
            {
                return Ok(result.ErrorMessage);
            }
            return Ok(result);
        }
        [Authorize(Roles = UserRolesConstant.AdminOrStaff)]
        [HttpPut]
        public async Task<IActionResult> UpdateMilkFunction([FromForm] UpdateMilkFunctionCommand command)
        {
            if (command == null)
            {
                return BadRequest();
            }
            var result = await _mediator.Send(command);
            if (!result.IsSuccess)
            {
                return BadRequest(result.ErrorMessage);
            }
            return Ok(result);
        }
        [Authorize(Roles = UserRolesConstant.AdminOrStaff)]
        [HttpDelete]
        public async Task<IActionResult> DeletetMilkFunction(Guid id)
        {
            var result = await _mediator.Send(new DeleteMilkFunctionCommand { Id = id });
            if (!result.IsSuccess)
            {
                return BadRequest(result.ErrorMessage);
            }
            return Ok(result);
        }


        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var command = new GetAllMilkFunctionCommand();
            var result = await _mediator.Send(command);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);

        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetById(Guid id)
        {
            var command = new GetByIdMilkFunctionCommand { Id = id };
            var result = await _mediator.Send(command);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        } 
    }
}
