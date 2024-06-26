using MediatR;
using SWPApi.Application.Nutrient.Responses;
using System.ComponentModel.DataAnnotations;

namespace SWPApi.Application.Nutrient.Commands
{
    public class GetByIdNutrientCommand:IRequest<GetByIdNutrientResponse>
    {
        [Required]
        public Guid Id { get; set; }
    }
}
