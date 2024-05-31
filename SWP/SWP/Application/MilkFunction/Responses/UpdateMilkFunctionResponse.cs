using Infrastructure.Models;

namespace SWPApi.Application.MilkFunction.Responses
{
    public class UpdateMilkFunctionResponse : BaseResponse
    {
        public Guid Id { get; set; }
        public string MilkFunctionName { get; set; }
    }
}
