using MediatR;
using SWPApi.Application.MilkBrand.Responses;
using SWPApi.Application.MilkFunction.Responses;
using System.ComponentModel.DataAnnotations;

namespace SWPApi.Application.MilkFunction.Commands
{
    public class GetByIdMilkFunctionCommand : IRequest<GetByIdMilkFunctionResponse>
    {
        [Required]
        public Guid Id { get; set; }
    }
}
