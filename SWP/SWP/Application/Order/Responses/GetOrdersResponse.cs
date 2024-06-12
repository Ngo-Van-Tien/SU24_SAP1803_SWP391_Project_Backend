using Infrastructure.Entities;
using Infrastructure.Models;

namespace SWPApi.Application.Order.Responses
{
    public class GetOrdersResponse : BaseResponse
    {
        public List<Infrastructure.Entities.Order> Data { get; set; }
    }
}
