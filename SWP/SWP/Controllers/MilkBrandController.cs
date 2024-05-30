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
        public async Task<IActionResult> AddMilkBrand([FromBody] AddMilkBrandCommand command)
        {
            if(command == null)
            {
                return BadRequest("MilkBrand had not yet been created");
            }
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        
    }
}
