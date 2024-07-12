using MediatR;
using SWPApi.Application.Company.Responses;

namespace SWPApi.Application.Company.Commands
{
    public class GetProductByCompanyCommand  : IRequest<GetProductByCompanyResponse>
    {
        public Guid Id { get; set; }
    }
}
