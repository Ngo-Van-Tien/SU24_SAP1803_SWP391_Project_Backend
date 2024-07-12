    using MediatR;
    using SWPApi.Application.Payments.Responses;

    namespace SWPApi.Application.Payments.Commands
    {
        public class CreatePaymentVnPayCommand : IRequest<CreatePaymentVnPayResponse>
        {
        public decimal Amount { get; set; }
        public string OrderId { get; set; }
         }
    }
