using Infrastructure.Models;

namespace SWPApi.Application.Order.Responses
{
    public class CancelOrderResponse : BaseResponse
    {
        public Infrastructure.Entities.Order Order { get; set; }
    }
}
