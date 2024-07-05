using Infrastructure.Models;

namespace SWPApi.Application.Order.Responses
{
    public class GetQuantityOrderResponse : BaseResponse
    {
        public int Quantity { get; set; }
    }
}
