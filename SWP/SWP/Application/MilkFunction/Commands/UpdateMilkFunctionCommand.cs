using MediatR;
using SWPApi.Application.MilkFunction.Responses;
using System.ComponentModel.DataAnnotations;

namespace SWPApi.Application.MilkFunction.Commands
{
    public class UpdateMilkFunctionCommand : IRequest<UpdateMilkFunctionResponse>
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
