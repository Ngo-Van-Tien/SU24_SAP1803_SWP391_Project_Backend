using MediatR;
using SWPApi.Application.Product.Responses;
using System.ComponentModel.DataAnnotations;

namespace SWPApi.Application.Product.Commands
{
    public class GetByPriceCommand : IRequest<GetByPriceResponse>
    {
        public decimal FPrice { get; set; }
        public decimal LPrice { get; set; }
        public int pageNumber { get; set; }
        public int pageSize { get; set; }
    }
}
