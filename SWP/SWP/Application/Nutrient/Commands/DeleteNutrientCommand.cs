using MediatR;
using SWPApi.Application.Nutrient.Responses;
using System.ComponentModel.DataAnnotations;

namespace SWPApi.Application.Nutrient.Commands
{
    public class DeleteNutrientCommand : IRequest<DeleteNutrientResponse>
    {
        [Required]
        public Guid Id { get; set; }
    }
}
