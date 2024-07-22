using Infrastructure.Constans;
using MediatR;
using Microsoft.AspNetCore.Identity;
using SWP.Infrastrcuture.Entities;
using SWPApi.Application.Account.Commands;
using SWPApi.Application.Account.Responses;
using System.ComponentModel.DataAnnotations;

namespace SWPApi.Application.Account.Handlers
{
    public class LockAccountHandler : IRequestHandler<LockAccountCommand, LockAccountResponse>
    {
        UserManager<AppUser> _userManager;
        public LockAccountHandler(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<LockAccountResponse> Handle(LockAccountCommand request, CancellationToken cancellationToken)
        {
            var response = new LockAccountResponse();
            
            var user = await _userManager.FindByIdAsync((request.Id).ToString());
            if(user == null || !user.LockoutEnabled)
            {
                response.ErrorMessage = "User is not existed";
                return response;
            }
            
            if (user.LockoutEnabled)
            {
                var roles = await _userManager.GetRolesAsync(user);
                if (roles.Contains(UserRolesConstant.Admin))
                {
                    response.ErrorMessage = "Admin accounts cannot be locked";
                    return response;
                }

                user.LockoutEnabled = false;
                var result = await _userManager.UpdateAsync(user);

                if (result.Succeeded)
                {
                    response.IsSuccess = true;
                }
                else
                {
                    response.ErrorMessage = "Failed to lock the account";
                }
            }
            else
            {
                response.ErrorMessage = "User is already locked";
            }

            return response;
        }
    }
}
