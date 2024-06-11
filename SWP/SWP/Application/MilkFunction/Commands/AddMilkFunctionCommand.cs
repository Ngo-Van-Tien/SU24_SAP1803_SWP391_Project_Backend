using MediatR;
using SWPApi.Application.MilkFunction.Responses;
using System.ComponentModel.DataAnnotations;

namespace SWPApi.Application.MilkFunction.Commands
{
    public class AddMilkFunctionCommand : IRequest<AddMilkFunctionResponse>
    {
        [Required]
        public string Name { get; set; }
    }
}
