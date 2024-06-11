using MediatR;
using SWPApi.Application.ProductItem.Response;

namespace SWPApi.Application.ProductItem.Commands
{
    public class GetProductItemsCommand : IRequest<GetProductItemsResponse>
    {
        public string? Name { get; set; }
        public int StartPrice { get; set; } = 0;
        public int EndPrice { get; set; }
        public List<int> Sizes { get; set; } = new List<int>();
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
