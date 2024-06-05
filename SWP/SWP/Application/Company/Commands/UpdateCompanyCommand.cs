using MediatR;
using SWPApi.Application.Company.Responses;
using System.ComponentModel.DataAnnotations;

namespace SWPApi.Application.Company.Commands
{
    public class UpdateCompanyCommand : IRequest<UpdateCompanyResponse>
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
        public string Nation { get; set; }
    }
}
