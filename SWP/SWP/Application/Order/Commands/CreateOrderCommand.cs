using Infrastructure.Entities;
using MediatR;
using SWPApi.Application.Order.Responses;

namespace SWPApi.Application.Order.Commands
{
    public class CreateOrderCommand : IRequest<CreateOrderResponse>
    {
        public List<Guid> ProductItemIds { get; set; }
        public decimal ShipFees { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
