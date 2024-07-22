using Infrastructure.Constans;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SWP.Infrastrcuture.Entities;
using SWPApi.Application.Account.Commands;
using SWPApi.Application.Account.Responses;
using System.ComponentModel.DataAnnotations;
using System.Net.WebSockets;
using System.Text.RegularExpressions;

namespace SWPApi.Application.Account.Handlers
{
    public class CreateAccountStaffHandler : IRequestHandler<CreateAccountStaffCommand, CreateAccountStaffResponse>
    {
        UserManager<AppUser> _usermanager;
        public CreateAccountStaffHandler(UserManager<AppUser> usermanager)
        {
            _usermanager = usermanager;
        }

        public async Task<CreateAccountStaffResponse> Handle(CreateAccountStaffCommand request, CancellationToken cancellationToken)
        {
            var response = new CreateAccountStaffResponse();
            if (string.IsNullOrEmpty(request.Email) || !new EmailAddressAttribute().IsValid(request.Email))
            {
                response.ErrorMessage = "Invalid email address";
                return response;
            }
            if (string.IsNullOrEmpty(request.PhoneNumber) || !new PhoneAttribute().IsValid(request.PhoneNumber))
            {
                response.ErrorMessage = "Phone number is invalid";
                return response;
            }
            var checkPhone = await _usermanager.Users.FirstOrDefaultAsync(u => u.PhoneNumber ==  request.PhoneNumber, cancellationToken);
            if(checkPhone != null)
            {
                response.ErrorMessage = "Phone number is already";
                return response;
            }
            var user = new AppUser
            {
                UserName = request.Email,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Address = request.Address,
            };
            var result = await _usermanager.CreateAsync(user, request.Password);
            
            if(result.Succeeded)
            {
                var resultRole = await _usermanager.AddToRoleAsync(user, UserRolesConstant.Staff);
                if(resultRole.Succeeded)
                {
                    response.IsSuccess = true;
                }
                else
                {
                    response.ErrorMessage = string.Join(", ", resultRole.Errors.Select(e => e.Description));  
                }
                
            }
            else
            {
                response.ErrorMessage = string.Join("", result.Errors.Select(e => e.Description));
            }
            return response;
        }

        private bool IsPhoneNumberValid(string phoneNumber)
        {
            // Biểu thức chính quy đơn giản để kiểm tra số điện thoại
            var phoneRegex = new Regex(@"^0\d{9,10}$");
            return phoneRegex.IsMatch(phoneNumber);
        }
    }
    
}
