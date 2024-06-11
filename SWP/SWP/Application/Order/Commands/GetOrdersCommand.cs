using MediatR;
using SWPApi.Application.Order.Responses;

namespace SWPApi.Application.Order.Commands
{
    public class GetOrdersCommand : IRequest<GetOrdersResponse>
    {
    }
}
