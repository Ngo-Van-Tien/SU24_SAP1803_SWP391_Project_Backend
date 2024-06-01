using MediatR;
using SWPApi.Application.Nutrient.Responses;

namespace SWPApi.Application.Nutrient.Commands
{
    public class AddNutrientCommand : IRequest<AddNutrientResponse>
    {
        public string? NutrientName { get; set; }
        public int? In100g { get; set; }
        public int? InCup { get; set; }
        public string unit { get; set; }
    }
}
