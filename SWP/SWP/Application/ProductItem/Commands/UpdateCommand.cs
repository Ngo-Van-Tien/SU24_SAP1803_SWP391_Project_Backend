using MediatR;
using Microsoft.AspNetCore.Mvc;
using SWPApi.Application.ProductItem.Response;
using System.ComponentModel.DataAnnotations;

namespace SWPApi.Application.ProductItem.Commands
{
    public class UpdateCommand : IRequest<UpdateResponse>
    {
        [Required]
        [FromForm]
        public Guid Id { get; set; }
        [Required]
        [FromForm]
        public int Quantity { get; set; }
        [Required]
        [FromForm]
        public decimal Price { get; set; }
        [Required]
        [FromForm]
        public int Size { get; set; }
        [FromForm]
        [Required]
        public Guid ProductId { get; set; }
    }
}
