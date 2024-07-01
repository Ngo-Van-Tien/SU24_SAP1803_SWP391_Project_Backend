﻿using Infrastructure.Models;

namespace SWPApi.Application.Account.Responses
{
    public class GetUserResponse : BaseResponse
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }    
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
    }
}
