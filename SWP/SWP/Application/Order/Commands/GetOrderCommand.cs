using MediatR;
using SWPApi.Application.Order.Responses;

namespace SWPApi.Application.Order.Commands
{
    public class GetOrderCommand : IRequest<GetOrderResponse>
    {
        public Guid Id { get;set; }
    }
}
