using Infrastructure.Models;

namespace SWPApi.Application.Product.Responses
{
    public class GetAllProductResponse:BaseResponse
    {
        public List<Infrastructure.Entities.Product> Products { get; set;}
    }
}
