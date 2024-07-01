using MediatR;
using Microsoft.AspNetCore.Mvc;
using SWPApi.Application.Account.Responses;
using System.ComponentModel.DataAnnotations;

namespace SWPApi.Application.Account.Commands
{
    public class LockAccountCommand : IRequest<LockAccountResponse>
    {
        [Required]
        [FromForm]
        public string Email { get; set; }
    }
}
