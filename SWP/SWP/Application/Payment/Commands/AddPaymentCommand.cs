using MediatR;
using Microsoft.AspNetCore.Mvc;
using SWPApi.Application.Payment.Responses;
using System.ComponentModel.DataAnnotations;

namespace SWPApi.Application.Payment.Commands
{
    public class AddPaymentCommand : IRequest<AddPaymentResponse>
    {
        [Required]
        [FromForm]
        public string Method { get; set; }
    }
}
