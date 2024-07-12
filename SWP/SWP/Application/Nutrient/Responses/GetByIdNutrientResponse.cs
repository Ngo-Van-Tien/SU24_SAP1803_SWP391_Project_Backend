using Infrastructure.Models;

namespace SWPApi.Application.Nutrient.Responses
{
    public class GetByIdNutrientResponse: BaseResponse
    {
        public Infrastructure.Entities.Nutrient Nutrient { get; set; }

    }
}
