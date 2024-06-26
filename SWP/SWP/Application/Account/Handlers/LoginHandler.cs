﻿using MediatR;
using Microsoft.AspNetCore.Identity;
using SWP.Infrastrcuture.Entities;
using SWPApi.Application.Account.Commands;
using SWPApi.Application.Account.Responses;

namespace SWPApi.Application.Account.Handlers
{
    public class LoginHandler : IRequestHandler<LoginCommand, LoginResponse>
    {
         SignInManager<AppUser> _signInManager;
         UserManager<AppUser> _userManager;
         JwtTokenHandler _tokenHandler;

        public LoginHandler(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, JwtTokenHandler tokenHandler)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _tokenHandler = tokenHandler;
        }
        public async Task<LoginResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            var response = new LoginResponse();
            if (user == null)
            {
                response.ErrorMessage = "User or password is not valid";
                return response;
            }
            var result = await _signInManager.PasswordSignInAsync(user, request.Password, false, false);
            if (result.Succeeded)
            {
                response.IsSuccess = true;
                response.Token = _tokenHandler.GenerateTokenString(user);
                
                return response;
            }
            return response;
        }


    }
}
