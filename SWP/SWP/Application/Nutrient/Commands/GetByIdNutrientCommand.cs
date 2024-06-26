using MediatR;
using Microsoft.AspNetCore.Mvc;
using SWPApi.Application.Nutrient.Responses;
using System.ComponentModel.DataAnnotations;

namespace SWPApi.Application.Nutrient.Commands
{
    public class GetByIdNutrientCommand:IRequest<GetByIdNutrientResponse>
    {
        [Required]
        [FromForm]
        public Guid Id { get; set; }
    }
}
