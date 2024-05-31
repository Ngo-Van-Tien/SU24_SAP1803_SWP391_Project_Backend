using MediatR;
using SWPApi.Application.MilkFunction.Responses;

namespace SWPApi.Application.MilkFunction.Commands
{
    public class AddMilkFunctionCommand : IRequest<AddMilkFunctionResponse>
    {
        public string MilkFunctionName { get; set; }
    }
}
