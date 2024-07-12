using Infrastructure.Models;

namespace SWPApi.Application.Nutrient.Responses
{
    public class UpdateNutrientResponse : BaseResponse
    {
        public Infrastructure.Entities.Nutrient Nutrient { get; set; }
    }
}
