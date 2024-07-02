using MediatR;
using Microsoft.AspNetCore.Mvc;
using SWPApi.Application.Account.Responses;
using System.ComponentModel.DataAnnotations;

namespace SWPApi.Application.Account.Commands
{
    public class LoginCommand : IRequest<LoginResponse>
    {
        [Required]
        [FromForm]
        public string Email { get; set; }
        [Required]
        [FromForm]
        public string Password { get; set; }
    }
}
