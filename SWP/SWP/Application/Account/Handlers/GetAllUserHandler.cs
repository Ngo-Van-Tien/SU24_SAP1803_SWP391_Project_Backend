using MediatR;
using Microsoft.AspNetCore.Identity;
using SWP.Infrastrcuture.Entities;
using SWPApi.Application.Account.Commands;
using SWPApi.Application.Account.Responses;

namespace SWPApi.Application.Account.Handlers
{
    public class GetAllUserHandler : IRequestHandler<GetAllUserCommand, GetAllUserResponse>
    {
        UserManager<AppUser> _userManager;
        public GetAllUserHandler(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<GetAllUserResponse> Handle(GetAllUserCommand request, CancellationToken cancellationToken)
        {
            var response = new GetAllUserResponse();
            var users = _userManager.Users.Select(u => new GetAllUserResponse.User
            {
                Id = u.Id,
                Email = u.Email,
                FirstName = u.FirstName,
                LastName = u.LastName,
                Address = u.Address,
                PhoneNumber = u.PhoneNumber,
                LockoutEnabled = u.LockoutEnabled
            }).ToList();

            response.Data = users;
            response.IsSuccess = true;

            return response;
        }
    }
}
