using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SWPApi.Application.MilkBrand.Commands;

namespace SWPApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MilkBrandController : ControllerBase
    {
        private readonly ISender _mediator;
        public MilkBrandController(ISender mediator)
        {
            _mediator = mediator;
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> AddMilkBrand([FromForm] AddMilkBrandCommand command)
        {
            if(command == null)
            {
                return BadRequest("MilkBrand had not yet been created");
            }
            var result = await _mediator.Send(command);
            if (!result.IsSuccess)
            {
                return BadRequest(result.ErrorMessage);
            }
            return Ok(result);
        }
        [AllowAnonymous]
        [HttpPut("update milk brand")]
        public async Task<IActionResult> UpdateMilkBrand( [FromForm] UpdateMilkBrandCommand command)
        {
            if(command == null) 
            {
                return BadRequest();
            }
            var result = await _mediator.Send(command);
            if(result == null)
            {
                return NotFound(result.ErrorMessage);
            }
            if (!result.IsSuccess)
            {
                return BadRequest(result.ErrorMessage);
            }   
            return Ok(result);
        }
        [AllowAnonymous]
        [HttpDelete("delete milk brand")]
        public async Task<IActionResult> DeleteMilkBrand(Guid Id)
        {
            
            var result = await _mediator.Send(new DeleteMilkBrandCommand { Id = Id});
            if (!result.IsSuccess)
            {
                return BadRequest(result.ErrorMessage);
            }
            return Ok(result);

        }
        
        [AllowAnonymous]
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllMilkBrand()
        {
            var result = await _mediator.Send(new GetAllMilkBrandCommand());
            if (!result.IsSuccess)
            {
                return BadRequest(result.ErrorMessage);
            }
            return Ok(result);
        }
    }
        
}
