using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using SWPApi.Application.Company.Commands;

namespace SWPApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ISender _mediator;

        public CompanyController(ISender mediator)
        {
            _mediator = mediator;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> AddCompany([FromBody] AddCompanyCommand command)
        {
            if(command == null)
            {
                return BadRequest();
            }
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [AllowAnonymous]
        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateCompany(Guid id, [FromBody] UpdateCompanyCommand command)
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
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteCompany(Guid id)
        {
            var result = await _mediator.Send(new DeleteCompanyCommand { Id = id});
            if (!result.IsSuccess)
            {
                return BadRequest(result.ErrorMessage);
            }
            return Ok(result);
        }

        [AllowAnonymous]
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllCompany()
        {
            var result = await _mediator.Send(new GetAllCompanyCommand());
            return Ok(result.Companies);
        }
    }
}
