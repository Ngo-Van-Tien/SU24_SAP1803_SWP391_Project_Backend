using MediatR;
using SWPApi.Application.Company.Responses;

namespace SWPApi.Application.Company.Commands
{
    public class UnLockCompanyCommand : IRequest<UnLockCompanyResponse>
    {
        public Guid Id { get; set; }
    }
}
