using MediatR;
using SWPApi.Application.ProductItem.Response;
using System.ComponentModel.DataAnnotations;
namespace SWPApi.Application.ProductItem.Commands;
using Microsoft.AspNetCore.Mvc;

public class DeleteCommand : IRequest<DeleteResponse>
{
    [Required]
    [FromForm]
    public Guid Id { get; set; }
}
