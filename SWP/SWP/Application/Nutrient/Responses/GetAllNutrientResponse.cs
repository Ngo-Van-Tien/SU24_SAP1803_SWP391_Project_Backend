using Infrastructure.Models;

namespace SWPApi.Application.Nutrient.Responses
{
    public class GetAllNutrientResponse: BaseResponse
    {
        public List<Infrastructure.Entities.Nutrient> Nutrients { get; set;}
    }
}
