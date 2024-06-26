using Infrastructure.Models;
using PagedList;

namespace SWPApi.Application.ProductItem.Response
{
    public class GetOutOfStockResponse : BaseResponse
    {
        public IPagedList<Infrastructure.Entities.ProductItem> Data { get; set; }
    }
}
