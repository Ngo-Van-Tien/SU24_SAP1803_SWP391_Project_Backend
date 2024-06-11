using Infrastructure.Entities;
using Infrastructure.Models;

namespace SWPApi.Application.Order.Responses
{
    public class CreateOrderResponse : BaseResponse
    {
        public Infrastructure.Entities.Order Order { get;set; }
    }
}
