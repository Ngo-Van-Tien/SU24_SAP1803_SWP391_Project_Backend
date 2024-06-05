using MediatR;
using SWPApi.Application.Company.Responses;
using System.ComponentModel.DataAnnotations;

namespace SWPApi.Application.Company.Commands
{
    public class DeleteCompanyCommand : IRequest<DeleteCompanyResponse>
    {
        [Required]
        public Guid Id { get; set; }
    }
}
