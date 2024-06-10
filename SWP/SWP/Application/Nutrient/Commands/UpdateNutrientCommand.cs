using MediatR;
using SWPApi.Application.Nutrient.Responses;
using System.ComponentModel.DataAnnotations;

namespace SWPApi.Application.Nutrient.Commands
{
    public class UpdateNutrientCommand : IRequest<UpdateNutrientResponse>
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int? In100g { get; set; }
        public int? InCup { get; set; }
        public string unit { get; set; }
    }
}
