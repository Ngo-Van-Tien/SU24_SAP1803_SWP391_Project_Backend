using Infrastructure.Models;
using PagedList;

namespace SWPApi.Application.ProductItem.Response
{
    public class GetProductItemsResponse : BaseResponse
    {
        public IPagedList<Infrastructure.Entities.ProductItem> Data { get; set; }
    }
}
