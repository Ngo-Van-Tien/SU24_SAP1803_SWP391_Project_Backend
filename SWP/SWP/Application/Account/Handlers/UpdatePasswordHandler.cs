using MediatR;
using Microsoft.AspNetCore.Identity;
using SWP.Infrastrcuture.Entities;
using SWPApi.Application.Account.Commands;
using SWPApi.Application.Account.Responses;

namespace SWPApi.Application.Account.Handlers
{
    public class UpdatePasswordHandler : IRequestHandler<UpdatePasswordCommand, UpdatePasswordResponse>
    {
        UserManager<AppUser> _userManager;
        public UpdatePasswordHandler(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<UpdatePasswordResponse> Handle(UpdatePasswordCommand request, CancellationToken cancellationToken)
        {
            var response = new UpdatePasswordResponse();
            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user == null)
            {
                response.ErrorMessage = "User does not exist";
                return response;
            }

            
            var passwordCheck = await _userManager.CheckPasswordAsync(user, request.Password);
            if (!passwordCheck)
            {
                response.ErrorMessage = "Current password is incorrect";
                return response;
            }

            
            var result = await _userManager.ChangePasswordAsync(user, request.Password, request.NewPassword);
            if (result.Succeeded)
            {
                response.IsSuccess = true;
            }
            else
            {
                response.ErrorMessage = string.Join("; ", result.Errors.Select(e => e.Description));
            }

            return response;
        }
    }
}
