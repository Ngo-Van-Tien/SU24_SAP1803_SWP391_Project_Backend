﻿using Infrastructure.Entities;
using Infrastructure.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace SWPApi.Application.Product.Responses
{
    public class AddProductResponse: BaseResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public int StartAge { get; set; }
        public int EndAge { get; set; } 
        public Infrastructure.Entities.MilkBrand MilkBrand { get; set; }
        public ImageFile? Image { get; set; }
    }
}
