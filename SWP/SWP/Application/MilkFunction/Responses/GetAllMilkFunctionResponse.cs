﻿using Infrastructure.Models;

namespace SWPApi.Application.MilkFunction.Responses
{
    public class GetAllMilkFunctionResponse: BaseResponse
    {
        public List<Infrastructure.Entities.MilkFunction> MilkFunction { get; set; }
    }
}
