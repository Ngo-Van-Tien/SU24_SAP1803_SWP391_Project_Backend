using Infrastructure.Models;

namespace SWPApi.Application.Company.Responses
{
    public class GetAllCompanyResponse : BaseResponse
    {
        public List<Infrastructure.Entities.Company> Companies;
        public GetAllCompanyResponse(List<Infrastructure.Entities.Company> companies)
        {
            Companies = companies;
        }
    }
}
