using AutoMapper;
using Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Identity;
using SWP.Infrastrcuture.Entities;
using SWPApi.Application.Account.Commands;
using SWPApi.Application.Account.Responses;
using System.Net;

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
            var user = new AppUser
            {
                UserName = request.Email,
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Address = request.Address
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
    }
}
