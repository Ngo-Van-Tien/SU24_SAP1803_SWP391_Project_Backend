using Infrastructure.Models;

namespace SWPApi.Application.ProductItem.Response
{
    public class GetAllProductItemResponse:BaseResponse
    {
        public List<Infrastructure.Entities.ProductItem> ProductItems { get; set; }
    }
}
