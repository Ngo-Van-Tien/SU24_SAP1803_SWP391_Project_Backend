using MediatR;
using Microsoft.AspNetCore.Mvc;
using SWPApi.Application.ProductItem.Response;
using System.ComponentModel.DataAnnotations;

namespace SWPApi.Application.ProductItem.Commands
{
    public class GetByIdProductItemCommand : IRequest<GetByIdProductItemResponse>
    {
        [Required]
        [FromForm]
        public Guid Id { get; set; }
    }
}
