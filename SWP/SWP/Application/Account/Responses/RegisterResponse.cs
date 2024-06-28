using Infrastructure.Models;

namespace SWPApi.Application.Account.Responses
{
    public class RegisterResponse : BaseResponse
    {
        public string Token { get; set; }
    }
}
