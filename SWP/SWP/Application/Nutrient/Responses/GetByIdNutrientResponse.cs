using Infrastructure.Models;

namespace SWPApi.Application.Nutrient.Responses
{
    public class GetByIdNutrientResponse: BaseResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

    }
}
