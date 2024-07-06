using MediatR;
using SWPApi.Application.ProductItem.Response;

namespace SWPApi.Application.ProductItem.Commands
{
    public class CountOutOfStockCommand : IRequest<CountOutOfStockResponse>
    {
    }
}
