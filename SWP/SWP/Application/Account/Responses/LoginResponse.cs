using Infrastructure.Models;

namespace SWPApi.Application.Account.Responses
{
    public class LoginResponse : BaseResponse
    {
        public string Token { get; set; }
    }
}
