using MediatR;
using Microsoft.AspNetCore.Mvc;
using SWPApi.Application.ProductItem.Response;

namespace SWPApi.Application.ProductItem.Commands
{
    public class GetProductItemsCommand : IRequest<GetProductItemsResponse>
    {
        [FromForm]
        public string? Name { get; set; }
        [FromForm]
        public int? StartPrice { get; set; } = 0;
        [FromForm]
        public int? EndPrice { get; set; }
        [FromForm]
        public int? StartAge { get; set; } = 0;
        [FromForm]
        public int? EndAge { get; set; }
        [FromForm]
        public List<int>? Sizes { get; set; } = new List<int>();
        [FromForm]
        public List<Guid>? MilkBrandIds { get; set; } = new List<Guid>();
        [FromForm]
        public int PageNumber { get; set; }
        [FromForm]
        public int PageSize { get; set; }
        [FromForm]
        public string? SortOrder { get; set; }
    }
}
