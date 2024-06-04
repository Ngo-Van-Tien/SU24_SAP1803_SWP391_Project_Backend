﻿using Infrastructure.Models;

namespace SWPApi.Application.MilkBrand.Responses
{
    public class UpdateMilkBrandResponse : BaseResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Infrastructure.Entities.Image Company { get; set; }
        public string? Description { get; set; }
    }
}
