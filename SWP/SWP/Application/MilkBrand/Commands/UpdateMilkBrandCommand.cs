using MediatR;
using Microsoft.AspNetCore.Mvc;
using SWPApi.Application.MilkBrand.Responses;
using System.ComponentModel.DataAnnotations;

namespace SWPApi.Application.MilkBrand.Commands
{
    public class UpdateMilkBrandCommand : IRequest<UpdateMilkBrandResponse>
    {
        [FromForm]
        [Required]
        public Guid Id { get; set; }
        [FromForm]
        [Required]
        public string Name { get; set; }
        [FromForm]
        [Required]
        public Guid CompanyId { get; set; }
        [FromForm]
        public string? Description { get; set; }
        [FromForm]
        [Required]
        public IFormFile Image { get; set; }
    }
}
