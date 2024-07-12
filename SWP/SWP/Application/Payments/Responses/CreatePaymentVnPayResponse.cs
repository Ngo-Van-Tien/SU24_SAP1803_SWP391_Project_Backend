using Infrastructure.Models;

namespace SWPApi.Application.Payments.Responses
{
    public class CreatePaymentVnPayResponse : BaseResponse
    {
        public string PaymentUrl { get; set; }
    }
}
