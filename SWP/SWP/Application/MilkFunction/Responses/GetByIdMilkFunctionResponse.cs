using Infrastructure.Models;

namespace SWPApi.Application.MilkFunction.Responses
{
    public class GetByIdMilkFunctionResponse : BaseResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
