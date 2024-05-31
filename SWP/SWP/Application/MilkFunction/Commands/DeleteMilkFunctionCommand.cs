using MediatR;
using SWPApi.Application.MilkFunction.Responses;

namespace SWPApi.Application.MilkFunction.Commands
{
    public class DeleteMilkFunctionCommand : IRequest<DeleteMilkFunctionResponse>
    {
        public Guid Id { get; set; }
    }
}
