using MediatR;
using Microsoft.AspNetCore.Mvc;
using SWPApi.Application.MilkFunction.Responses;
using System.ComponentModel.DataAnnotations;

namespace SWPApi.Application.MilkFunction.Commands
{
    public class UpdateMilkFunctionCommand : IRequest<UpdateMilkFunctionResponse>
    {
        [Required]
        [FromForm]
        public Guid Id { get; set; }
        [Required]
        [FromForm]
        public string Name { get; set; }
    }
}
