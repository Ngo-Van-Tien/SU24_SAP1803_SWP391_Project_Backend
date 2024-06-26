using MediatR;
using Microsoft.AspNetCore.Mvc;
using SWPApi.Application.MilkFunction.Responses;
using System.ComponentModel.DataAnnotations;

namespace SWPApi.Application.MilkFunction.Commands
{
    public class AddMilkFunctionCommand : IRequest<AddMilkFunctionResponse>
    {
        [Required]
        [FromForm]
        public string Name { get; set; }
    }
}
