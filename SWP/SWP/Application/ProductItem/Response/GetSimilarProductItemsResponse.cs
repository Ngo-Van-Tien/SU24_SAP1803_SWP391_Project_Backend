using Infrastructure.Models;

namespace SWPApi.Application.ProductItem.Response
{
    public class GetSimilarProductItemsResponse : BaseResponse
    {
        public List<Infrastructure.Entities.ProductItem> Data { get; set; }
    }
}
