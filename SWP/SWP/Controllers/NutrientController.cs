﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SWPApi.Application.Nutrient.Commands;
using System.Runtime.CompilerServices;

namespace SWPApi.Controllers
{
    [Route("api/[controller]")]
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
        public async Task<IActionResult> AddNutrient([FromBody]AddNutrientCommand command)
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
        public async Task<IActionResult> UpdateNutrient( [FromBody] UpdateNutrientCommand command)
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
            var result = await _mediator.Send( new  DeleteNutrientCommand() {  Id = id });
            if(!result.IsSuccess)
            {
                return BadRequest(result.ErrorMessage);
            }
            return Ok(result);
        }
    }
}
