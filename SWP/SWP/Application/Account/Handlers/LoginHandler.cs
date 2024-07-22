using Infrastructure.Constans;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SWP.Infrastrcuture.Entities;
using SWPApi.Application.Account.Commands;
using SWPApi.Application.Account.Responses;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SWPApi.Application.Account.Handlers
{
    public class LoginHandler : IRequestHandler<LoginCommand, LoginResponse>
    {
         SignInManager<AppUser> _signInManager;
         UserManager<AppUser> _userManager;
        IConfiguration _configuration;
        public LoginHandler(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, IConfiguration configuration)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _configuration = configuration;
        }
        public async Task<LoginResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var response = new LoginResponse();
            if (string.IsNullOrEmpty(request.Email) || !new EmailAddressAttribute().IsValid(request.Email))
            {
                response.ErrorMessage = "Invalid email address";
                return response;
            }
            var user = await _userManager.FindByEmailAsync(request.Email);
            
            if (user == null || !user.LockoutEnabled)
            {
                response.ErrorMessage = "User or password is not valid";
                return response;
            }
            var result = await _signInManager.PasswordSignInAsync(user, request.Password, false, false);
            if (result.Succeeded)
            {
                response.FirstName = user.FirstName;
                response.LastName = user.LastName;
                response.Email = user.Email;
                response.Address = user.Address;
                response.PhoneNumber = user.PhoneNumber;
                response.IsSuccess = true;
                response.Token = await GenerateTokenString(user);
                
                return response;
            }
            else
            {
                response.ErrorMessage = "User or password is not corrrect";
                return response;
;            }
            return response;
        }

        private async Task<string> GenerateTokenString(AppUser user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Sub, user.Id),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("FirstName", user.FirstName),
                new Claim("LastName", user.LastName),
                new Claim("PhoneNumber", user.PhoneNumber),
                new Claim("Address", user.Address )
            };

            var userRoles = await _userManager.GetRolesAsync(user);
            foreach (var role in userRoles) {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            SecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("Jwt:Key").Value));
            SigningCredentials signingCred = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            var securityToken = new JwtSecurityToken(
            claims: claims,
                expires: DateTime.Now.AddMinutes(1440),
                issuer: _configuration.GetSection("Jwt:Issuer").Value,
                audience: _configuration.GetSection("Jwt:Audience").Value,
                signingCredentials: signingCred);
            var tokenString = new JwtSecurityTokenHandler().WriteToken(securityToken);
            return tokenString;
        }


    }
}
