using MediatR;
using SWPApi.Application.ProductItem.Response;

namespace SWPApi.Application.ProductItem.Commands
{
    public class GetSimilarProductItemsCommand : IRequest<GetSimilarProductItemsResponse>
    {
         public Guid Id { get; set; }
         public Guid ProductId { get; set; }

    }
}
