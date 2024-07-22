using Infrastructure.Constans;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SWPApi.Application.MilkFunction.Commands;
using SWPApi.Application.ProductItem.Commands;

namespace SWPApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductItemController : ControllerBase
    {
        private readonly ISender _mediator;
        public ProductItemController(ISender mediator)
        {
            _mediator = mediator;
        }

        [Authorize(Roles = UserRolesConstant.AdminOrStaff)]
        [HttpPost]
        public async Task<IActionResult> add([FromForm] AddCommand command)
        {
            if (command == null)
            {
                return BadRequest();
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
        public async Task<IActionResult> update([FromForm] UpdateCommand command)
        {
            if (command == null)
            {
                return BadRequest();
            }
            var result = await _mediator.Send(command);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [Authorize(Roles = UserRolesConstant.AdminOrStaff)]
        [HttpDelete]
        public async Task<IActionResult> delete([FromForm] DeleteCommand command)
        {
            if (command == null)
            {
                return BadRequest();
            }
            var result = await _mediator.Send(command);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> GetProductItems([FromForm]GetProductItemsCommand command)
        {
            if (command == null)
            {
                return BadRequest();
            }
            var result = await _mediator.Send(command);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);

        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var command = new GetAllProductItemCommand();
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
            var command = new GetByIdProductItemCommand { Id = id };
            var result = await _mediator.Send(command);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [Authorize(Roles = UserRolesConstant.AdminOrStaff)]
        [HttpPost]
        public async Task<IActionResult> GetOutOfStock(GetOutOfStockCommand command)
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

        public async Task<IActionResult> GetQuantity()
        {
            var command = new CountProductItemCommand();
            var result = await _mediator.Send(command);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [Authorize(Roles = UserRolesConstant.AdminOrStaff)]
        [HttpPost]
        public async Task<IActionResult> GetQuantityOutOfStock()
        {
            var command = new CountOutOfStockCommand();
            var result = await _mediator.Send(command);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> getsimilarproductitems(GetSimilarProductItemsCommand command)
        {
            var resutl = await _mediator.Send(command);
            if (!resutl.IsSuccess)
            {
                return BadRequest(resutl);
            }
            return Ok(resutl);
        }
    }
}
