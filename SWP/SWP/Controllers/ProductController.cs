using Infrastructure.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SWPApi.Application.MilkBrand.Commands;
using SWPApi.Application.MilkFunction.Commands;
using SWPApi.Application.Product.Commands;
using System.Drawing.Printing;

namespace SWPApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ProductController : ControllerBase
    {
        private readonly ISender _mediator;
        public ProductController(ISender mediator) 
        {
            _mediator = mediator;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> getproduct(Guid id)
        {
            var result = await _mediator.Send(new GetProductCommand() { Id = id });
            return Ok(result);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> addproduct([FromForm] AddProductCommand command)
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

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> updateproduct([FromForm] UpdateProductCommand command)
        {
            if (command == null)
            {
                return BadRequest();
            }

            var result = await _mediator.Send(command);
            if (result == null)
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
        [HttpPost]
        public async Task<IActionResult> getbyname(GetByNameCommand command)
        {
            
            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }


        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> getbymilkbrand(GetByMilkBrandCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
        [AllowAnonymous]
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllProduct()
        {
            var result = await _mediator.Send(new GetAllProductCommand());
            if (!result.IsSuccess)
            {
                return BadRequest(result.ErrorMessage);
            }
            return Ok(result.Products);
        }

    }
}
