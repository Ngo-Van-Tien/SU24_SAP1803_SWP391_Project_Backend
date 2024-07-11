using MediatR;
using Microsoft.AspNetCore.Mvc;
using SWPApi.Application.Company.Responses;
using System.ComponentModel.DataAnnotations;

namespace SWPApi.Application.Company.Commands
{
    public class UpdateCompanyCommand : IRequest<UpdateCompanyResponse>
    {
        [FromForm]
        [Required]
        public Guid Id { get; set; }
        [FromForm]
        [Required]
        public string Name { get; set; }
        [FromForm]
        [Required]
        public string Description { get; set; }
        [FromForm]
        [Required]
        public string Nation { get; set; }
        [FromForm]
        [Required]
        public IFormFile Image { get; set; }
        [FromForm]
        [Required]
        public string Path { get; set; }
    }
}
