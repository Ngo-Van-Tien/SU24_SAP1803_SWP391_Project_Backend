using Infrastructure.Models;

namespace SWPApi.Application.MilkFunction.Responses
{
    public class AddMilkFunctionResponse : BaseResponse
    {
        public Infrastructure.Entities.MilkFunction MilkFunction { get; set; }
    }
}
