using Infrastructure.Models;

namespace SWPApi.Application.Company.Responses
{
    public class GetProductByCompanyResponse : BaseResponse
    {
        public List<Infrastructure.Entities.ProductItem> Data { get; set; } = new List<Infrastructure.Entities.ProductItem>();
    }
}
