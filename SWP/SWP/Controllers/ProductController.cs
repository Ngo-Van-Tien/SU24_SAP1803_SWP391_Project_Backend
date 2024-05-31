﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SWPApi.Application.Product.Commands;

namespace SWPApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ISender _mediator;
        public ProductController(ISender mediator) 
        {
            _mediator = mediator;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetProduct(Guid id)
        {
            var result = await _mediator.Send(new GetProductCommand() { Id = id });
            return Ok(result);
        }
        [AllowAnonymous]
        [HttpPost("AddProduct")]

        public async Task<IActionResult> AddProduct([FromBody] AddProductCommand command)
        {
            if (command == null)
            {
                return BadRequest("Invalid product data.");
            }

            var result = await _mediator.Send(command);
            if (result == null || !result.IsSuccess)
            {
                return BadRequest(result?.ErrorMessage ?? "An error occurred while creating the product.");
            }

            return Ok(result);
        }


    }
}
