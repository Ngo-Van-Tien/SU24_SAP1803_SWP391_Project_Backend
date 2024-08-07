﻿using Infrastructure.Models;
using PagedList;

namespace SWPApi.Application.Account.Responses
{
    public class GetAllUserResponse : BaseResponse
    {
        public class User
        {
            public string Id { get; set; }
            public string Email { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Address { get; set; }
            public string PhoneNumber { get; set; }
            public bool LockoutEnabled { get; set; }
            public string Role { get; set; }
        }

        public IPagedList<User> Data { get; set; }
    }
}
