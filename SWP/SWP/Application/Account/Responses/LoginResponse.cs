using Infrastructure.Models;

namespace SWPApi.Application.Account.Responses
{
    public class LoginResponse : BaseResponse
    {
        string Token { get; set; }
    }
}
