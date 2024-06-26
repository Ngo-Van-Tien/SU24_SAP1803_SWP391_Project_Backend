﻿using Infrastructure.Models;

namespace SWPApi.Application.Nutrient.Responses
{
    public class UpdateNutrientResponse : BaseResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
