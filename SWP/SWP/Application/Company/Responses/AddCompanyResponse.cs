using Infrastructure.Models;

namespace SWPApi.Application.Company.Responses
{
    public class AddCompanyResponse : BaseResponse
    {
        public Infrastructure.Entities.Company Company { get; set; }
    }
}
