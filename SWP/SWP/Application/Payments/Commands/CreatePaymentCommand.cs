using MediatR;
using SWPApi.Application.Payments.Responses;

namespace SWPApi.Application.Payments.Commands
{
    public class CreatePaymentCommand : IRequest<CreatePaymentResponse>
    {
        public string Method { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal PaymentAmount { get; set; }
        public Guid OrderId { get; set; }
    }
}
