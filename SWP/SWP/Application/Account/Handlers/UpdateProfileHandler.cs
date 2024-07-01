using MediatR;
using Microsoft.AspNetCore.Identity;
using SWP.Infrastrcuture.Entities;
using SWPApi.Application.Account.Commands;
using SWPApi.Application.Account.Responses;

namespace SWPApi.Application.Account.Handlers
{
    public class UpdateProfileHandler : IRequestHandler<UpdateProfileCommand, UpdateProfileResponse>
    {
        UserManager<AppUser> _userManager;
        public UpdateProfileHandler(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<UpdateProfileResponse> Handle(UpdateProfileCommand request, CancellationToken cancellationToken)
        {
            var response = new UpdateProfileResponse();
            var user = await _userManager.FindByEmailAsync(request.Email);    
            if (user == null)
            {
                response.ErrorMessage = "User is not existed";
                return response;
            }

            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.Address = request.Address;
            user.PhoneNumber = request.PhoneNumber;

            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                response.IsSuccess = true;
            }else
            {
                response.ErrorMessage = "Failed to update profile";
            }
            return response;
        }
    }
}
