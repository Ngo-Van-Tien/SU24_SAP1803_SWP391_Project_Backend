using MediatR;
using SWPApi.Application.ProductItem.Response;

namespace SWPApi.Application.ProductItem.Commands
{
    public class CountProductItemCommand : IRequest<CountProductItemResponse>
    {
    }
}
