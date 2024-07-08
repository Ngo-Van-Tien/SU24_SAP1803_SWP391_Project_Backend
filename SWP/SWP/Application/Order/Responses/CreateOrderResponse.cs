using Infrastructure.Entities;
using Infrastructure.Models;

namespace SWPApi.Application.Order.Responses
{
    public class CreateOrderResponse : BaseResponse
    {
        public Guid Id { get; set; }
        public Infrastructure.Entities.Order Order { get;set; }
    }
}
