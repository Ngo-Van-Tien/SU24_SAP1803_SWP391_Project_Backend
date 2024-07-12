using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SWPApi.Application.Product.Responses;

namespace SWPApi.Application.Product.Commands
{
    public class UpdateProductCommand: IRequest<UpdateProductResponse>
    {
        [Required]
        [FromForm]
        public Guid Id { get; set; }
        [Required]
        [FromForm]
        public string Name { get; set; }
        [FromForm]
        public string? Description { get; set; }
        [Required]
        [FromForm]
        public int StartAge { get; set; }
        
        [FromForm]
        public int EndAge { get; set; }
        [Required]
        [FromForm]
        public Guid MilkBrandId { get; set; }
        [Required]
        [FromForm]
        public IFormFile? Image { get; set; }
    }
}
