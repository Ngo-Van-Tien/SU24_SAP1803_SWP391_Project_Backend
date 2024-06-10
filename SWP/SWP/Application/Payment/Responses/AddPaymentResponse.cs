using Infrastructure.Models;

namespace SWPApi.Application.Payment.Responses
{
    public class AddPaymentResponse : BaseResponse
    {
        public Guid Id { get; set; }
        public string Method { get; set; }
    }
}
