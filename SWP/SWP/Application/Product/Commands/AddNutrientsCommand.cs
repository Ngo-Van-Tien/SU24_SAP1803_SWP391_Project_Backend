using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;
using SWPApi.Application.Product.Responses;
using System.ComponentModel.DataAnnotations;

namespace SWPApi.Application.Product.Commands
{
    public class AddNutrientsCommand : IRequest<AddNutrientsResponse>
    {
        [Required]
        public Guid Id { get; set; }
        public List<NutrientDetail>? Nutrients { get; set; } = new List<NutrientDetail>();

        public class NutrientDetail
        {
            public Guid Id { get; set; }
            public double? In100g { get; set; }
            public double? InCup { get; set; }
            public string? Unit { get; set; }
        }
    }
}
