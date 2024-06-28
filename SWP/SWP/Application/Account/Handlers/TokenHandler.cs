using Microsoft.IdentityModel.Tokens;
using SWP.Infrastrcuture.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SWPApi.Application.Account.Handlers
{
    public class TokenHandler
    {
        IConfiguration _configuration;

        public TokenHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateTokenString(AppUser user)
        {
            return null;
        }
    }
}
