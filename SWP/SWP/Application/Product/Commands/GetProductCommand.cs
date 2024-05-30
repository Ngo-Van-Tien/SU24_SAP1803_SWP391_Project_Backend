using MediatR;
using SWPApi.Application.Product.Responses;

namespace SWPApi.Application.Product.Commands
{
    public class GetProductCommand : IRequest<GetProductResponse>
    {
        public Guid Id { get; set; }
    }
}
