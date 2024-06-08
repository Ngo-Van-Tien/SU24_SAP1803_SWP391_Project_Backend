using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SWPApi.Application.MilkFunction.Commands;

namespace SWPApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MilkFunctionController : ControllerBase
    {
        private readonly ISender _mediator;

        public MilkFunctionController(ISender mediator)
        {
            _mediator = mediator;
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> AddMilkFunction([FromBody] AddMilkFunctionCommand command)
        {
            if(command == null)
            {
                return BadRequest();
            }
            var result = await _mediator.Send(command);
            if(!result.IsSuccess)
            {
                return Ok(result.ErrorMessage);
            }
            return Ok(result);
        }
        [AllowAnonymous]
        [HttpPut]
        public async Task<IActionResult> UpdateMilkFunction( [FromBody] UpdateMilkFunctionCommand command)
        {
            if(command == null)
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
        [AllowAnonymous]
        [HttpDelete]
        public async Task<IActionResult> DeletetMilkFunction(Guid Id)
        {
            var result = await _mediator.Send(new DeleteMilkFunctionCommand { Id = Id});
            if (!result.IsSuccess)
            {
                return BadRequest(result.ErrorMessage);
            }
            return Ok(result);
        }
    }
}
