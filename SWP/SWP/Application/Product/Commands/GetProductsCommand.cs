using MediatR;
using Microsoft.AspNetCore.Mvc;
using SWPApi.Application.Product.Responses;

namespace SWPApi.Application.Product.Commands
{
    public class GetProductsCommand : IRequest<GetProductsResponse>
    {
        public string? Name { get;set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
