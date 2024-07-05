using MediatR;
using SWPApi.Application.Order.Responses;

namespace SWPApi.Application.Order.Commands
{
    public class GetQuantityOrderCommand : IRequest<GetQuantityOrderResponse>
    {
        public string? Status { get; set; }
    }
}
