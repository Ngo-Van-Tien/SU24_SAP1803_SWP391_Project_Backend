using MediatR;
using SWPApi.Application.MilkFunction.Responses;

namespace SWPApi.Application.MilkFunction.Commands
{
    public class GetAllMilkFunctionCommand : IRequest<GetAllMilkFunctionResponse>
    {
    }
}
