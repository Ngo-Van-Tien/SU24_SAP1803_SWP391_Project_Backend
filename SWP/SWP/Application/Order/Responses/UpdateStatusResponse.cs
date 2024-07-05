using Infrastructure.Models;

namespace SWPApi.Application.Order.Responses
{
    public class UpdateStatusResponse : BaseResponse
    {
        public Infrastructure.Entities.Order Order { get; set; }
    }
}
