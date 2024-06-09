using Infrastructure.Models;
using PagedList;

namespace SWPApi.Application.Product.Responses
{
    public class GetByPriceResponse : BaseResponse
    {
        public IPagedList<Infrastructure.Entities.Product> Data { get; set; }
    }
}
