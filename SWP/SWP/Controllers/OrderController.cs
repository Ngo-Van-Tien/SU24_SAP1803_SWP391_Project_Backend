using Infrastructure.Constans;
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

        [Authorize]
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

        [Authorize]
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

        [Authorize]
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

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> GetByStatus([FromForm] GetOrderByStatusCommand command)
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
        public async Task<IActionResult> GeyQuantityByStatus([FromForm] GetQuantityOrderCommand command)
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
        public async Task<IActionResult> SaleReport([FromForm]  SaleReportCommand command)
        {
            var result = await _mediator.Send(command);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [Authorize(Roles = UserRolesConstant.AdminOrStaff)]
        [HttpGet]
        public async Task<IActionResult> top5highestsalse()
        {
            var command = new Top5ProductHightestSaleCommand();
            var result = await _mediator.Send(command);
            if(!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [Authorize(Roles = UserRolesConstant.AdminOrStaff)]
        [HttpGet]
        public async Task<IActionResult> top5leastsalse()
        {
            var command = new Top5ProductLeaestSaleCommand();
            var result = await _mediator.Send(command);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> cancelorder([FromForm] CancelOrderCommand command)
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
        public async Task<IActionResult> updatestatus([FromForm] UpdateStatusCommand command)
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
        public async Task<IActionResult> getdetailorder([FromForm] GetDetailOrderCommand command)
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
