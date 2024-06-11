using MediatR;
using SWPApi.Application.MilkBrand.Responses;
using System.ComponentModel.DataAnnotations;

namespace SWPApi.Application.MilkBrand.Commands
{
    public class GetByIdMilkBrandCommand : IRequest<GetByIdMilkBrandResponse>
    {
        [Required]
        public Guid Id { get; set; }
    }
}
