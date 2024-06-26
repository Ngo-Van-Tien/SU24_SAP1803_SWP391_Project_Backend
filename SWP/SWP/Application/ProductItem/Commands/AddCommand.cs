using MediatR;
using Microsoft.AspNetCore.Mvc;
using SWPApi.Application.ProductItem.Response;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SWPApi.Application.ProductItem.Commands
{
    public class AddCommand : IRequest<AddResponse>
    {
        [Required]
        [FromForm]
        public int Quantity { get; set; }
        [Required]
        [FromForm]
        public decimal Price { get; set; }
        [Required]
        [FromForm]
        public int Size { get; set; }
        [Required]
        [FromForm]
        public Guid ProductId { get; set; }
    }
}
