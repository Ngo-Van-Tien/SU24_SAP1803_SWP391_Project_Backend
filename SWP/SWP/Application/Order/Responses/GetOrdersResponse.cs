using Infrastructure.Entities;
using Infrastructure.Models;

namespace SWPApi.Application.Order.Responses
{
    public class GetOrdersResponse : BaseResponse
    {
        public List<OrderDisplay> Data { get; set; }

        public class OrderDisplay
        {
            public Guid Id { get; set; }
            public string Status { get; set; }
            public string StatusPayment { get; set; }
            public string Address { get; set; }
            public DateTimeOffset CreateDate { get; set; }
        } 
    }
}
