using Infrastructure.Models;

namespace SWPApi.Application.MilkFunction.Responses
{
    public class AddMilkFunctionResponse : BaseResponse
    {
        public Guid Id { get; set; }
        public string MilkFunctionName { get; set; }
    }
}
