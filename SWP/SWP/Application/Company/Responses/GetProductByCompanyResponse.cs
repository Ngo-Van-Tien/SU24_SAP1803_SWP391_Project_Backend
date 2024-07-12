using Infrastructure.Models;

namespace SWPApi.Application.Company.Responses
{
    public class GetProductByCompanyResponse : BaseResponse
    {
        public Infrastructure.Entities.Company Company { get; set; }
        public List<Infrastructure.Entities.Product> Products { get; set; } = new List<Infrastructure.Entities.Product>();
    }
}
