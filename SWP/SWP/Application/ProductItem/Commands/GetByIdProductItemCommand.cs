using MediatR;
using SWPApi.Application.ProductItem.Response;
using System.ComponentModel.DataAnnotations;

namespace SWPApi.Application.ProductItem.Commands
{
    public class GetByIdProductItemCommand : IRequest<GetByIdProductItemResponse>
    {
        [Required]
        public Guid Id { get; set; }
    }
}
