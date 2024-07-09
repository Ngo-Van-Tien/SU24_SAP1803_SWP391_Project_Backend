using Infrastructure.Entities;
using Infrastructure.Models;

namespace SWPApi.Application.Order.Responses
{
    public class GetOrderResponse : BaseResponse
    {
        public Guid Id { get; set; }
        public decimal TotalPriceProduct { get; set; }
        public decimal ShipFees { get; set; }
        public decimal FinalPrice { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Status { get; set; }
        public string StatusPayment { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public List<Infrastructure.Entities.OrderDetail> OrderDetails { get; set; }
    }
}
