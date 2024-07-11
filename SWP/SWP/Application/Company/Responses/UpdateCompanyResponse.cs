using Infrastructure.Models;

namespace SWPApi.Application.Company.Responses
{
    public class UpdateCompanyResponse : BaseResponse
    {
        public Infrastructure.Entities.Company Company { get; set; }
    }
}
