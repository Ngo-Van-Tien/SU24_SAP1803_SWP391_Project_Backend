    using MediatR;
    using SWPApi.Application.Payments.Responses;
using System.Runtime.CompilerServices;

namespace SWPApi.Application.Payments.Commands
    {
        public class CreatePaymentVnPayCommand : IRequest<CreatePaymentVnPayResponse>
        {
        public Guid OrderId { get; set; }
        }
    }
