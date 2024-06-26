using MediatR;
using Microsoft.AspNetCore.Mvc;
using SWPApi.Application.Product.Responses;
using System.ComponentModel.DataAnnotations;

namespace SWPApi.Application.Product.Commands
{
    public class DeleteProductCommand : IRequest<DeleteProductResponse>
    {
        [FromForm]
        [Required]
        public Guid Id { get; set; }
    }
}
