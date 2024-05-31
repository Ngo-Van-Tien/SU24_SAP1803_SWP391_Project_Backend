using MediatR;
using SWPApi.Application.Company.Responses;

namespace SWPApi.Application.Company.Commands
{
    public class GetAllCompanyCommand : IRequest<GetAllCompanyResponse>
    {
    }
}
