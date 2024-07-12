using Infrastructure.Models;

namespace SWPApi.Application.Nutrient.Responses
{
    public class AddNutrientResponse : BaseResponse
    {
        public Infrastructure.Entities.Nutrient Nutrient { get; set; }
    }
}
