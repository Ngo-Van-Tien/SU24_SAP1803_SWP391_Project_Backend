using MediatR;
using SWPApi.Application.Account.Responses;

namespace SWPApi.Application.Account.Commands
{
    public class GetAllUserCommand : IRequest<GetAllUserResponse>
    {
        public int pageNumber { get; set; }
        public int pageSize { get; set; }   
    }
}
