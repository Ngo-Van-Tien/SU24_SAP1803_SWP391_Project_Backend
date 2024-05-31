using MediatR;
using SWPApi.Application.MilkFunction.Responses;

namespace SWPApi.Application.MilkFunction.Commands
{
    public class UpdateMilkFunctionCommand : IRequest<UpdateMilkFunctionResponse>
    {
        public Guid Id { get; set; }
        public string MilkFunctionName { get; set; }
    }
}
