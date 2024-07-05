using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SWPApi.Application.Payments.Commands;

namespace SWPApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly ISender _mediator;
        public PaymentController(ISender mediator)
        {
            _mediator = mediator;
        }

        
        [HttpPost]
        public async Task<IActionResult> CreatePayment([FromForm] CreatePaymentCommand command)
        {
            if(command == null)
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

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetPayment(int pageNumber, int PageSize)
        {
            var command = new GetPaymentsCommand() { PageNumber = pageNumber, PageSize = PageSize };
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
    }
}
