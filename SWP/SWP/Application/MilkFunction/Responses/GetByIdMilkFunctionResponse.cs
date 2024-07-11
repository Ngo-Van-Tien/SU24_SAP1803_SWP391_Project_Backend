using Infrastructure.Models;

namespace SWPApi.Application.MilkFunction.Responses
{
    public class GetByIdMilkFunctionResponse : BaseResponse
    {
        public Infrastructure.Entities.MilkFunction MilkFunction { get; set; }
    }
}
