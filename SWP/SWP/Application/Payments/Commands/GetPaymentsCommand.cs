using MediatR;
using SWPApi.Application.Payments.Responses;

namespace SWPApi.Application.Payments.Commands
{
    public class GetPaymentsCommand : IRequest<GetPaymentsResponse>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
