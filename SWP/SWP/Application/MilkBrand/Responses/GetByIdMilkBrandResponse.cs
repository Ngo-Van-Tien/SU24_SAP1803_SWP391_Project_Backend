using Infrastructure.Models;

namespace SWPApi.Application.MilkBrand.Responses
{
    public class GetByIdMilkBrandResponse : BaseResponse
    {
        public Infrastructure.Entities.MilkBrand MilkBrand { get; set; }
    }
}
