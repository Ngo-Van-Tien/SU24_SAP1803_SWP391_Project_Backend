using MediatR;
using Microsoft.AspNetCore.Mvc;
using SWPApi.Application.Product.Responses;
using System.ComponentModel.DataAnnotations;

namespace SWPApi.Application.Product.Commands
{
    public class DeleteNutrientsCommand : IRequest<DeleteNutrientsResponse>
    {
        [FromForm]
        [Required]
        public Guid Id { get; set; }
        [FromForm]
        [Required]
        public Guid NutrientId { get; set; }
    }
}
