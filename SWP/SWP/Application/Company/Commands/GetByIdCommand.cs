using MediatR;
using SWPApi.Application.Company.Responses;
using System.ComponentModel.DataAnnotations;

namespace SWPApi.Application.Company.Commands
{
    public class GetByIdCommand : IRequest<GetByIdResponse>
    {
        [Required]
        public Guid Id { get; set; }
    }
}
