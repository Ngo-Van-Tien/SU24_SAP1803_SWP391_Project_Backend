using MediatR;
using Microsoft.AspNetCore.Mvc;
using SWPApi.Application.Order.Responses;

namespace SWPApi.Application.Order.Commands
{
    public class GetReportCommand : IRequest<GetReportResponse>
    {
        [FromForm]
        public DateTimeOffset StartDay { get; set; }
        [FromForm]
        public DateTimeOffset EndDay { get; set;}
    }
}
