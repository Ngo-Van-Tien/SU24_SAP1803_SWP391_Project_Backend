using MediatR;
using SWPApi.Application.Company.Responses;
using System.ComponentModel.DataAnnotations;

namespace SWPApi.Application.Company.Commands
{
    public class AddCompanyCommand : IRequest<AddCompanyResponse>
    {
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
        public string Nation { get; set; }
    }
}
