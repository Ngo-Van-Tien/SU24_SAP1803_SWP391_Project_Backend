using Infrastructure.Models;

namespace SWPApi.Application.Company.Responses
{
    public class GetByIdResponse : BaseResponse
    {
        public Infrastructure.Entities.Company Company { get; set; }
    }
}
