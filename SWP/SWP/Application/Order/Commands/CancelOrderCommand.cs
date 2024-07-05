using MediatR;
using SWPApi.Application.Order.Responses;

namespace SWPApi.Application.Order.Commands
{
    public class CancelOrderCommand : IRequest<CancelOrderResponse>
    { 
        public Guid Id { get; set; }
    }
}
