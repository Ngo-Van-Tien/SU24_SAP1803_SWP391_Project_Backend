﻿
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SWPApi.Application.Product.Responses;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SWPApi.Application.Product.Commands
{
    public class AddProductCommand: IRequest<AddProductResponse>
    {

        [Required]
        [FromForm]
        public string Name { get; set; }
        [FromForm]
        public string? Description { get; set; }
        [Required]
        [FromForm]
        public int StartAge { get; set; }
        [FromForm]
        public int? EndAge { get; set; }
        [Required]
        [FromForm]
        public Guid MilkBrandId { get; set; }
        [Required]
        [FromForm]
        public IFormFile Image { get; set; }
        
    }
 
}

