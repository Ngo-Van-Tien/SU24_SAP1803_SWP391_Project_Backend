using MediatR;
using Microsoft.AspNetCore.Mvc;
using SWPApi.Application.Product.Responses;
using System.ComponentModel.DataAnnotations;

namespace SWPApi.Application.Product.Commands
{

    public class NutrientDetail
    {
        [Required]
        [FromForm]
        public Guid NutrientId { get; set; }
        [Required]
        [FromForm]
        public double? In100g { get; set; }
        [Required]
        [FromForm]
        public double? InCup { get; set; }
        [Required]
        [FromForm]
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
        public List<NutrientDetail> Nutrients { get; set; }
    }
}
