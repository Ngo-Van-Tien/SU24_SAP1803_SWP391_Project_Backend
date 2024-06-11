using Infrastructure.Models;

namespace SWPApi.Application.Nutrient.Responses
{
    public class GetNutrientsResponse : BaseResponse
    {
        public List<Infrastructure.Entities.Nutrient> Data { get; set; }
    }
}
