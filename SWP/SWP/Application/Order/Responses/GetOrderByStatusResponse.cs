using Infrastructure.Models;

namespace SWPApi.Application.Order.Responses
{
    public class GetOrderByStatusResponse : BaseResponse
    {
        public List<Infrastructure.Entities.Order> Data { get; set; }
    }
}
