using MediatR;
using Microsoft.AspNetCore.Identity;
using SWP.Infrastrcuture.Entities;
using SWPApi.Application.Account.Commands;
using SWPApi.Application.Account.Responses;

namespace SWPApi.Application.Account.Handlers
{
    public class GetUserHandler : IRequestHandler<GetUserCommand, GetUserResponse>
    {
        UserManager<AppUser> _userManager;
        public GetUserHandler(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<GetUserResponse> Handle(GetUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            var response = new GetUserResponse();
            if (user == null)
            {
                response.ErrorMessage = "User is not existed";
                return response;
            }

            response = new GetUserResponse
            {
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Address = user.Address,
                PhoneNumber = user.PhoneNumber
            };
            response.IsSuccess = true;

            return response;
        }
    }
}
