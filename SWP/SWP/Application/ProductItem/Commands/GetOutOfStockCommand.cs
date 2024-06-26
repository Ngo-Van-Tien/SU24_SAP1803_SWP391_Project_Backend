using MediatR;
using SWPApi.Application.ProductItem.Response;

namespace SWPApi.Application.ProductItem.Commands
{
    public class GetOutOfStockCommand : IRequest<GetOutOfStockResponse>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
