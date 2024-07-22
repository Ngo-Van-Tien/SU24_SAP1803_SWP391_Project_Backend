using Infrastructure.Models;

namespace SWPApi.Application.Order.Responses
{
    public class GetReportResponse : BaseResponse
    {
        public int TotalQuantity { get; set; }
        public int TotalQuantityCancel { get; set; }
        public decimal TotalDeliver { get; set; }
        public decimal TotalFinal { get; set; }
    }
}
