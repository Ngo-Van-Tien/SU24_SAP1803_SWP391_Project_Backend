using MediatR;
using Microsoft.AspNetCore.Identity;
using SWP.Infrastrcuture.Entities;
using SWPApi.Application.Account.Commands;
using SWPApi.Application.Account.Responses;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

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
            if (string.IsNullOrEmpty(request.Email) || !new EmailAddressAttribute().IsValid(request.Email))
            {
                response.ErrorMessage = "Invalid email address";
                return response;
            }
            if (string.IsNullOrEmpty(request.PhoneNumber) || !IsPhoneNumberValid(request.PhoneNumber))
            {
                response.ErrorMessage = "Invalid phone number";
                return response;
            }
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

        private bool IsPhoneNumberValid(string phoneNumber)
        {
            var phoneRegex = new Regex(@"^0\d{9,10}$");
            return phoneRegex.IsMatch(phoneNumber);
        }
    }
}
