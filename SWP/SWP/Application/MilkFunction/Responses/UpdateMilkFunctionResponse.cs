using Infrastructure.Models;

namespace SWPApi.Application.MilkFunction.Responses
{
    public class UpdateMilkFunctionResponse : BaseResponse
    {
        public Infrastructure.Entities.MilkFunction MilkFunction { get; set; }
    }
}
