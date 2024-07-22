using MediatR;
using Microsoft.AspNetCore.Identity;
using SWP.Infrastrcuture.Entities;
using SWPApi.Application.Account.Commands;
using SWPApi.Application.Account.Responses;
using System.ComponentModel.DataAnnotations;

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
            var response = new GetUserResponse();
            if (string.IsNullOrEmpty(request.Email) || !new EmailAddressAttribute().IsValid(request.Email))
            {
                response.ErrorMessage = "Invalid email address";
                return response;
            }
            var user = await _userManager.FindByEmailAsync(request.Email);
            
            if (user == null || !user.LockoutEnabled)
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
                PhoneNumber = user.PhoneNumber,
                IsSuccess = true
        };
            

            return response;
        }
    }
}
