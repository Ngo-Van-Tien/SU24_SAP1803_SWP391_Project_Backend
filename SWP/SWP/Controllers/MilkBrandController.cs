using Infrastructure.Constans;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SWPApi.Application.MilkBrand.Commands;

namespace SWPApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MilkBrandController : ControllerBase
    {
        private readonly ISender _mediator;
        public MilkBrandController(ISender mediator)
        {
            _mediator = mediator;
        }
        [Authorize(Roles = UserRolesConstant.AdminOrStaff)]
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
                return BadRequest(result);
            }
            return Ok(result);
        }
        [Authorize(Roles = UserRolesConstant.AdminOrStaff)]
        [HttpPut]
        public async Task<IActionResult> UpdateMilkBrand( [FromForm] UpdateMilkBrandCommand command)
        {
            if(command == null) 
            {
                return BadRequest();
            }
            var result = await _mediator.Send(command);
            if(result == null)
            {
                return NotFound(result);
            }
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }   
            return Ok(result);
        }
        [Authorize(Roles = UserRolesConstant.AdminOrStaff)]
        [HttpDelete]
        public async Task<IActionResult> DeleteMilkBrand(Guid id)
        {
            
            var result = await _mediator.Send(new DeleteMilkBrandCommand {Id=id });
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);

        }
        
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAllMilkBrand()
        {
            var result = await _mediator.Send(new GetAllMilkBrandCommand());
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
            var command = new GetByIdMilkBrandCommand { Id = id };
            var result = await _mediator.Send(command);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
        
}
