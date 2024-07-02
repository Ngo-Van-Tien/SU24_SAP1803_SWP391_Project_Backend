using MediatR;
using Microsoft.AspNetCore.Mvc;
using SWPApi.Application.Order.Responses;
using System.ComponentModel.DataAnnotations;

namespace SWPApi.Application.Order.Commands
{
    public class GetOrderByStatusCommand : IRequest<GetOrderByStatusResponse>
    {
        [FromForm]
        [Required]
        public string Status { get; set; }
    }
}
