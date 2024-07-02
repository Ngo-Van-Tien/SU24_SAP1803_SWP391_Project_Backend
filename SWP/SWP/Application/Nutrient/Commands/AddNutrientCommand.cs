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

    }
}
