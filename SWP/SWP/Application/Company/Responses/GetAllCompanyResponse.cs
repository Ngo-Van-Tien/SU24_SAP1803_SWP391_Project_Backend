using Infrastructure.Models;

namespace SWPApi.Application.Company.Responses
{
    public class GetAllCompanyResponse : BaseResponse
    {
        public List<Infrastructure.Entities.Company> Companies;
    }
}
