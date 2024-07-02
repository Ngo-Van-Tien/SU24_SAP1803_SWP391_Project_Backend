using MediatR;
using SWPApi.Application.Account.Responses;

namespace SWPApi.Application.Account.Commands
{
    public class GetUserCommand : IRequest<GetUserResponse>
    {
        public string Email { get; set; }
    }
}
