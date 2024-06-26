using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SWPApi.Application.MilkBrand.Commands;
using SWPApi.Application.Nutrient.Commands;
using System.Runtime.CompilerServices;

namespace SWPApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class NutrientController : ControllerBase
    {
        private readonly ISender _mediator;
        public NutrientController(ISender mediator)
        {
            _mediator = mediator;
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> AddNutrient([FromForm]AddNutrientCommand command)
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
        [HttpPut]
        public async Task<IActionResult> UpdateNutrient( [FromForm] UpdateNutrientCommand command)
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
        public async Task<IActionResult> DeleteNutrient(Guid id)
        {
            var command = new DeleteNutrientCommand { Id=id};
            var result = await _mediator.Send(command);
            if(!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetNutrients()
        {
            var command = new GetNutrientsCommand(); 
            var result = await _mediator.Send(command);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetByIdNutrient(Guid id)
        {
            var result = await _mediator.Send(new GetByIdNutrientCommand { Id=id});
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
