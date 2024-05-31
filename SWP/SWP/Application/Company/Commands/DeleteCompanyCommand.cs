using MediatR;
using SWPApi.Application.Company.Responses;

namespace SWPApi.Application.Company.Commands
{
    public class DeleteCompanyCommand : IRequest<DeleteCompanyResponse>
    {
        public Guid Id { get; set; }
    }
}
