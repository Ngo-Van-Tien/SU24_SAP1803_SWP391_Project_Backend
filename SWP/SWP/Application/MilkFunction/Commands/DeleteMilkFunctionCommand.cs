﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using SWPApi.Application.MilkFunction.Responses;
using System.ComponentModel.DataAnnotations;

namespace SWPApi.Application.MilkFunction.Commands
{
    public class DeleteMilkFunctionCommand : IRequest<DeleteMilkFunctionResponse>
    {
        [FromForm]
        [Required]
        public Guid Id { get; set; }
    }
}
