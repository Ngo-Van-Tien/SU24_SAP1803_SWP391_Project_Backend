using MediatR;
using SWPApi.Application.Account.Responses;

namespace SWPApi.Application.Account.Commands
{
    public class UpdateProfileCommand : IRequest<UpdateProfileResponse>
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }

    }
}
