﻿using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SWPApi.Application.Product.Responses;

namespace SWPApi.Application.Product.Commands
{
    public class UpdateProductCommand: IRequest<UpdateProductResponse>
    {
        [FromForm]
        public Guid Id { get; set; }
        [FromForm]
        public string Name { get; set; }
        public string? Description { get; set; }
        [FromForm]
        public decimal? Price { get; set; }
        [FromForm]
        public string? AgeRange { get; set; }
        [FromForm]
        public Guid? MilkBrandId { get; set; }
        [FromForm]
        public IFormFile? Image { get; set; }
    }
}
