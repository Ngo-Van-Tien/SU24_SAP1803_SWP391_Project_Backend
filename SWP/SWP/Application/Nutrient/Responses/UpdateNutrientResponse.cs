using Infrastructure.Models;

namespace SWPApi.Application.Nutrient.Responses
{
    public class UpdateNutrientResponse : BaseResponse
    {
        public Guid Id { get; set; }
        public string? NutrientName { get; set; }
        public int? In100g { get; set; }
        public int? InCup { get; set; }
        public string unit { get; set; }
    }
}
