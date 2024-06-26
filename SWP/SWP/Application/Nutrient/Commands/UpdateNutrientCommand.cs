﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using SWPApi.Application.Nutrient.Responses;
using System.ComponentModel.DataAnnotations;

namespace SWPApi.Application.Nutrient.Commands
{
    public class UpdateNutrientCommand : IRequest<UpdateNutrientResponse>
    {
        [Required]
        [FromForm]
        public Guid Id { get; set; }
        [Required]
        [FromForm]
        public string Name { get; set; }
       

    }
}
