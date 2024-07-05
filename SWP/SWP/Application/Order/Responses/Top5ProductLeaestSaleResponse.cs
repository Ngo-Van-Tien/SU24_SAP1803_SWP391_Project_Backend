using Infrastructure.Models;

namespace SWPApi.Application.Order.Responses
{
    public class Top5ProductLeaestSaleResponse : BaseResponse
    {
        public List<ProductSalesDetail> TopProducts { get; set; }

        public Top5ProductLeaestSaleResponse()
        {
            TopProducts = new List<ProductSalesDetail>();
        }

        public class ProductSalesDetail
        {
            public string ProductName { get; set; }
            public int QuantitySold { get; set; }
            public decimal TotalSales { get; set; }
        }
    }
}
