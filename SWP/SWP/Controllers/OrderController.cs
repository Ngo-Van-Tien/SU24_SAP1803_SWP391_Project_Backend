using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SWPApi.Application.Order.Commands;
using SWPApi.Application.Product.Commands;

namespace SWPApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ISender _mediator;
        public OrderController(ISender mediator)
        {
            _mediator = mediator;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> CreateOrder(CreateOrderCommand command)
        {
            var result = await _mediator.Send(command);
            if (result == null || !result.IsSuccess)
            {
                return BadRequest(result?.ErrorMessage ?? "An error occurred while creating the order.");
            }

            return Ok(result);
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetOrder(Guid id)
        {
            var command = new GetOrderCommand { Id = id };
            var result = await _mediator.Send(command);
            if (result == null || !result.IsSuccess)
            {
                return BadRequest(result?.ErrorMessage ?? "An error occurred while get the order.");
            }

            return Ok(result);
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            var command = new GetOrdersCommand();
            var result = await _mediator.Send(command);
            if (result == null || !result.IsSuccess)
            {
                return BadRequest(result?.ErrorMessage ?? "An error occurred while get all the orders.");
            }

            return Ok(result);
        }
    }
}
