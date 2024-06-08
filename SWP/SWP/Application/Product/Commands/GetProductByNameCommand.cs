using MediatR;
using SWPApi.Application.Product.Responses;

namespace SWPApi.Application.Product.Commands
{
    public class GetProductByNameCommand : IRequest<GetProductByNameResponse>
    {
        public string Name { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
