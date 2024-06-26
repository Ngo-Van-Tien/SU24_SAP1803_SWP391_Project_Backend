using MediatR;
using Microsoft.AspNetCore.Mvc;
using SWPApi.Application.Nutrient.Responses;
using System.ComponentModel.DataAnnotations;

namespace SWPApi.Application.Nutrient.Commands
{
    public class DeleteNutrientCommand : IRequest<DeleteNutrientResponse>
    {
        [Required]
        [FromForm]
        public Guid Id { get; set; }
    }
}
