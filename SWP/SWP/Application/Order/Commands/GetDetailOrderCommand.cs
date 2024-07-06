using MediatR;
using SWPApi.Application.Order.Responses;

namespace SWPApi.Application.Order.Commands
{
    public class GetDetailOrderCommand : IRequest<GetDetailOrderResponse>
    {
        public Guid Id { get; set; }
    }
}
