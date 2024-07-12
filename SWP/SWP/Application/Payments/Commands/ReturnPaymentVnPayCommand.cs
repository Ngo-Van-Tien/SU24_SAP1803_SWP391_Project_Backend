using MediatR;
using SWPApi.Application.Payments.Responses;

namespace SWPApi.Application.Payments.Commands
{
    public class ReturnPaymentVnPayCommand : IRequest<ReturnPaymentVnPayResponse>
    {
        public IQueryCollection QueryString { get; set; }
    }
}
