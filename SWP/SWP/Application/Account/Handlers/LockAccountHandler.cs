using MediatR;
using Microsoft.AspNetCore.Identity;
using SWP.Infrastrcuture.Entities;
using SWPApi.Application.Account.Commands;
using SWPApi.Application.Account.Responses;

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
            var user = await _userManager.FindByEmailAsync(request.Email);
            if(user == null)
            {
                response.ErrorMessage = "User is not existed";
                return response;
            }
            user.LockoutEnabled = false;
            var result = await _userManager.UpdateAsync(user);
            if(result.Succeeded)
            {
                response.IsSuccess = true;
            }
            return response;
        }
    }
}
