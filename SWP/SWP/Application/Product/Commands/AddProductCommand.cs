using MediatR;
using Microsoft.AspNetCore.Mvc;
using SWPApi.Application.Product.Responses;
using System.ComponentModel.DataAnnotations;

namespace SWPApi.Application.Product.Commands
{

    public class NutrientDetail
    {
        [Required]
        public Guid NutrientId { get; set; }
        [Required]
        public double? In100g { get; set; }
        [Required]
        public double? InCup { get; set; }
        [Required]
        public string Unit { get; set; }
    }
    public class AddProductCommand: IRequest<AddProductResponse>
    {

        [Required]
        [FromForm]
        public string Name { get; set; }
        [FromForm]
        public string? Description { get; set; }
        [Required]
        [FromForm]
        public int StartAge { get; set; }
        [Required]
        [FromForm]
        public int EndAge { get; set; }
        [Required]
        [FromForm]
        public Guid MilkBrandId { get; set; }
        [Required]
        [FromForm]
        public IFormFile Image { get; set; }
        [Required]
        [FromForm]
        public List<NutrientDetail> Nutrients { get; set; } = new List<NutrientDetail>();
    }
}
