using Infrastructure.Models;

namespace SWPApi.Application.ProductItem.Response
{
    public class CountOutOfStockResponse : BaseResponse
    {
        public int Quantity { get; set; }
    }
}
