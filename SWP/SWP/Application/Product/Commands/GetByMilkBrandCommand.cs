using MediatR;
using Microsoft.AspNetCore.Mvc;
using SWPApi.Application.Product.Responses;
using System.ComponentModel.DataAnnotations;

namespace SWPApi.Application.Product.Commands
{
    public class GetByMilkBrandCommand : IRequest<GetByMilkBrandResponse>
    {
        [Required]
        [FromForm]
        public Guid Id { get; set; }
        public int pageNumber { get; set; }
        public int pageSize { get; set; }
    }
}
