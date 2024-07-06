using MediatR;
using SWPApi.Application.Order.Responses;

namespace SWPApi.Application.Order.Commands
{
    public class UpdateStatusCommand : IRequest<UpdateStatusResponse>
    {
        public Guid Id { get; set; }
        public string Status { get; set; }
        public string StatusPayment { get; set; }
    }
}
