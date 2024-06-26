using MediatR;
using Microsoft.AspNetCore.Mvc;
using SWPApi.Application.Nutrient.Responses;
using System.ComponentModel.DataAnnotations;

namespace SWPApi.Application.Nutrient.Commands
{
    public class AddNutrientCommand : IRequest<AddNutrientResponse>
    {
        [FromForm]
        [Required]
        public string Name { get; set; }
        [FromForm]
        [Required]
        public int In100g { get; set; }
        [FromForm]
        [Required]
        public int InCup { get; set; }
        [FromForm]
        [Required]
        public string Unit { get; set; }
    }
}
