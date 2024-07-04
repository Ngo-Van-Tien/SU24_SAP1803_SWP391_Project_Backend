using Infrastructure.Models;

namespace SWPApi.Application.Company.Responses
{
    public class AddCompanyResponse : BaseResponse
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Nation { get; set; }
    }
}
