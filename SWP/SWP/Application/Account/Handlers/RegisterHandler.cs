using AutoMapper;
using Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Identity;
using SWP.Infrastrcuture.Entities;
using SWPApi.Application.Account.Commands;
using SWPApi.Application.Account.Responses;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text.RegularExpressions;

namespace SWPApi.Application.Account.Handlers
{
    public class RegisterHandler : IRequestHandler<RegisterCommand, RegisterResponse>
    {
        UserManager<AppUser> _userManager;
        IMapper _mapper;
       

        public RegisterHandler(UserManager<AppUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async  Task<RegisterResponse> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {

            var response = new RegisterResponse();
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
            var user = new AppUser
            {
                UserName = request.Email,
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Address = request.Address,
                PhoneNumber = request.PhoneNumber
            };

            var result = await _userManager.CreateAsync(user, request.Password);

            if (result.Succeeded)
            {
                response.IsSuccess = true;
            }
            else
            {
                response.ErrorMessage = string.Join(", ", result.Errors.Select(e => e.Description));
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
