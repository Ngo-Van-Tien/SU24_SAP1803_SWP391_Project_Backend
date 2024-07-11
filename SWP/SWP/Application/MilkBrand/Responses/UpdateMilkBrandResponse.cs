using Infrastructure.Models;

namespace SWPApi.Application.MilkBrand.Responses
{
    public class UpdateMilkBrandResponse : BaseResponse
    {
        public Infrastructure.Entities.MilkBrand MilkBrand { get; set; }
    }
}
