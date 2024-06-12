using Infrastructure.Entities;
using Infrastructure.Models;
using PagedList;

namespace SWPApi.Application.Product.Responses
{
    public class GetByNameResponse : BaseResponse
    {
        public IPagedList<Infrastructure.Entities.Product> Data { get; set; }
    }
}
