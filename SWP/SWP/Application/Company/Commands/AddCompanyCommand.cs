using MediatR;
using SWPApi.Application.Company.Responses;

namespace SWPApi.Application.Company.Commands
{
    public class AddCompanyCommand : IRequest<AddCompanyResponse>
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public string Nation { get; set; }
    }
}
