using Infrastructure.Constans;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using SWPApi.Application.Company.Commands;

namespace SWPApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ISender _mediator;

        public CompanyController(ISender mediator)
        {
            _mediator = mediator;
        }

        [Authorize(Roles = UserRolesConstant.AdminOrStaff)]
        [HttpPost]
        public async Task<IActionResult> AddCompany([FromForm] AddCompanyCommand command)
        {
            if(command == null)
            {
                return BadRequest();
            }
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [Authorize(Roles = UserRolesConstant.AdminOrStaff)]
        [HttpPut]
        public async Task<IActionResult> UpdateCompany([FromForm] UpdateCompanyCommand command)
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
        [Authorize(Roles = UserRolesConstant.Admin)]
        [HttpDelete]
        public async Task<IActionResult> DeleteCompany(Guid id)
        {
            var result = await _mediator.Send(new DeleteCompanyCommand { Id = id});
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [Authorize(Roles = UserRolesConstant.AdminOrStaff)]
        [HttpGet]
        public async Task<IActionResult> GetAllCompany()
        {
            var command = new GetAllCompanyCommand();
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
            var command = new GetByIdCommand { Id = id };
            var result = await _mediator.Send(command);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [Authorize(Roles = UserRolesConstant.AdminOrStaff)]
        [HttpGet]
        public async Task<IActionResult> GetQuantity()
        {
            var command = new CountCompanyCommand();
            var result = await _mediator.Send(command);
            if(!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
