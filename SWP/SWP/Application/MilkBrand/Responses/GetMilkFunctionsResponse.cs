using Infrastructure.Models;

namespace SWPApi.Application.MilkBrand.Responses
{
    public class GetMilkFunctionsResponse : BaseResponse
    {
        public List<Infrastructure.Entities.MilkFunction> Data { get; set; }
    }
}
