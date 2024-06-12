using Infrastructure.Entities;
using Infrastructure.Models;

namespace SWPApi.Application.Payments.Responses
{
    public class GetPaymentsResponse : BaseResponse
    {
        public List<Payment> Data { get; set; }
    }
}
