using MediatR;
using Microsoft.AspNetCore.Mvc;
using SWPApi.Application.Account.Responses;
using System.ComponentModel.DataAnnotations;

namespace SWPApi.Application.Account.Commands
{
    public class CreateAccountStaffCommand : IRequest<CreateAccountStaffResponse>
    {
        [Required]
        [FromForm]
        public string FirstName { get; set; }
        [Required]
        [FromForm]
        public string LastName { get; set; }
        [Required]
        [FromForm]
        public string Email { get; set; }
        [Required]
        [FromForm]
        public string Password { get; set; }
        [Required]
        [FromForm]
        public string Address { get; set; }
        [Required]
        [FromForm]
        public string PhoneNumber { get; set; }
    }
}
