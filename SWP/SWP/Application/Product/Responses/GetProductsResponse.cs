using Infrastructure.Models;
using PagedList;

namespace SWPApi.Application.Product.Responses
{
    public class GetProductsResponse : BaseResponse
    {
        public IPagedList<Infrastructure.Entities.Product> Data { get; set; }
        public int TotalElements { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
    }
}
