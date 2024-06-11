using MediatR;
using SWPApi.Application.Product.Responses;

namespace SWPApi.Application.Product.Commands
{
    public class GetAllProductCommand:IRequest<GetAllProductResponse>
    {
    }
}
