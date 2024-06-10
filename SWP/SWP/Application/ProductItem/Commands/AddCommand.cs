using MediatR;
using Microsoft.AspNetCore.Mvc;
using SWPApi.Application.ProductItem.Response;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SWPApi.Application.ProductItem.Commands
{
    public class AddCommand : IRequest<AddResponse>
    {
        [FromForm]
        public int Quantity { get; set; }
        [FromForm]
        public decimal Price { get; set; }
        [FromForm]
        public int Size { get; set; }
        [FromForm]
        [Required]
        public Guid? ProductId { get; set; }
    }
}
