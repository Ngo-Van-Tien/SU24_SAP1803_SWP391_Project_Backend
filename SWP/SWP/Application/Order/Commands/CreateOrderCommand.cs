using Infrastructure.Entities;
using MediatR;
using SWPApi.Application.Order.Responses;

namespace SWPApi.Application.Order.Commands
{
    public class CreateOrderCommand : IRequest<CreateOrderResponse>
    {
        public class ProductRequest
        {
            public Guid Id { get; set; }
            public int Quantity { get; set; }
        }

        public List<ProductRequest> ProductItems { get; set; }
        public string UserId { get; set; }
    }
}
